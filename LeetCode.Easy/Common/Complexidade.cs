using System.Diagnostics;
using System.Text;

namespace LeetCode.Easy.Common;

/// <summary>
/// Classes de complexidade de tempo (notação Big-O) que dá para distinguir medindo o tempo de execução.
/// </summary>
public enum ComplexidadeDeTempo
{
    /// <summary>O(1) constante ou O(log n) logarítmica: o tempo quase não muda quando n cresce.</summary>
    ConstanteOuLogaritmica = 0,

    /// <summary>O(n) linear ou O(n log n) linearítmica: dobrar n ≈ dobra o tempo.</summary>
    Linear = 1,

    /// <summary>O(n²) quadrática: dobrar n ≈ quadruplica o tempo.</summary>
    Quadratica = 2,

    /// <summary>O(n³) cúbica ou pior: dobrar n multiplica o tempo por 8 ou mais.</summary>
    CubicaOuPior = 3,
}

/// <summary>
/// Motor de medição da complexidade de tempo, de forma EMPÍRICA.
/// <para>
/// Roda a solução com entradas de pior caso em tamanhos crescentes (500, 1.000, 2.000, 4.000, 8.000),
/// mede o tempo de cada chamada e calcula o expoente k da curva tempo ≈ c · nᵏ
/// (regressão linear em escala log-log). k ≈ 0 → O(1)/O(log n), k ≈ 1 → O(n), k ≈ 2 → O(n²)...
/// </para>
/// <para>Quem usa isto é a classe AnaliseDeComplexidade (na raiz do projeto).</para>
/// </summary>
public static class Complexidade
{
    private static readonly int[] TamanhosPadrao = [500, 1_000, 2_000, 4_000, 8_000];
    private static readonly TimeSpan AlvoPorMedicao = TimeSpan.FromMilliseconds(15);
    private static readonly TimeSpan Aquecimento = TimeSpan.FromMilliseconds(250);
    private static readonly TimeSpan LimiteParaParar = TimeSpan.FromMilliseconds(500);
    private const int Rodadas = 5;

    // Duas medições ao mesmo tempo disputariam CPU e distorceriam os números.
    private static readonly Lock Trava = new();

    /// <summary>Mede a solução e devolve os tempos e a complexidade estimada.</summary>
    /// <param name="criarEntrada">Gera a entrada de PIOR CASO para um tamanho n. Roda fora do cronômetro.</param>
    /// <param name="executar">Chama a solução com a entrada gerada.</param>
    /// <param name="recriarEntradaACadaExecucao">
    /// Use <c>true</c> quando a solução altera a entrada (in-place, listas ligadas...),
    /// para cada execução receber uma entrada nova.
    /// </param>
    /// <param name="tamanhos">Tamanhos de n a testar (opcional, mínimo 3, em ordem crescente).</param>
    public static MedicaoDeComplexidade Medir<TEntrada, TResultado>(
        Func<int, TEntrada> criarEntrada,
        Func<TEntrada, TResultado> executar,
        bool recriarEntradaACadaExecucao = false,
        int[]? tamanhos = null)
    {
        var ns = tamanhos ?? TamanhosPadrao;
        if (ns.Length < 3)
            throw new ArgumentException("Informe pelo menos 3 tamanhos.", nameof(tamanhos));

        lock (Trava)
        {
            // Prioridade alta reduz a chance do Windows jogar a medição para um núcleo mais lento no meio do caminho.
            var thread = Thread.CurrentThread;
            var prioridadeOriginal = thread.Priority;
            try
            {
                thread.Priority = ThreadPriority.Highest;
                return MedirTodosOsTamanhos(ns, criarEntrada, executar, recriarEntradaACadaExecucao);
            }
            finally
            {
                thread.Priority = prioridadeOriginal;
            }
        }
    }

    private static MedicaoDeComplexidade MedirTodosOsTamanhos<TEntrada, TResultado>(
        int[] ns,
        Func<int, TEntrada> criarEntrada,
        Func<TEntrada, TResultado> executar,
        bool recriarEntradaACadaExecucao)
    {
        Aquecer(ns[0], criarEntrada, executar);

        var pontos = new List<PontoMedicao>();
        foreach (var n in ns)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var segundos = recriarEntradaACadaExecucao
                ? MedirRecriando(n, criarEntrada, executar)
                : MedirEmLote(criarEntrada(n), executar);

            pontos.Add(new PontoMedicao(n, Math.Max(segundos, 1e-12)));

            // Já está lento demais: com 3 pontos dá pra estimar, não precisa esperar os tamanhos maiores.
            if (pontos.Count >= 3 && segundos > LimiteParaParar.TotalSeconds)
                break;
        }

        return new MedicaoDeComplexidade(pontos, Debugger.IsAttached);
    }

    /// <summary>Nome da classe de complexidade, com a notação Big-O.</summary>
    public static string Descrever(ComplexidadeDeTempo complexidade) => complexidade switch
    {
        ComplexidadeDeTempo.ConstanteOuLogaritmica => "O(1) ou O(log n), constante ou logarítmica",
        ComplexidadeDeTempo.Linear => "O(n) ou O(n log n), linear",
        ComplexidadeDeTempo.Quadratica => "O(n²), quadrática",
        _ => "O(n³) ou pior, cúbica ou pior",
    };

    // Roda a solução por um tempo para o JIT otimizar o código antes de medir de verdade.
    private static void Aquecer<TEntrada, TResultado>(
        int n, Func<int, TEntrada> criarEntrada, Func<TEntrada, TResultado> executar)
    {
        long inicio = Stopwatch.GetTimestamp();
        while (Stopwatch.GetElapsedTime(inicio) < Aquecimento)
            Sumidouro<TResultado>.Valor = executar(criarEntrada(n));
    }

    // Entrada reaproveitada: cronometra lotes de chamadas (bom para operações muito rápidas).
    private static double MedirEmLote<TEntrada, TResultado>(TEntrada entrada, Func<TEntrada, TResultado> executar)
    {
        long lote = 1;
        double tempo = CronometrarLote(entrada, executar, lote);
        while (tempo < AlvoPorMedicao.TotalSeconds && lote < (1L << 30))
        {
            lote *= 2;
            tempo = CronometrarLote(entrada, executar, lote);
        }

        double melhor = tempo / lote;
        for (int r = 1; r < Rodadas; r++)
            melhor = Math.Min(melhor, CronometrarLote(entrada, executar, lote) / lote);

        return melhor;
    }

    private static double CronometrarLote<TEntrada, TResultado>(
        TEntrada entrada, Func<TEntrada, TResultado> executar, long lote)
    {
        long inicio = Stopwatch.GetTimestamp();
        for (long i = 0; i < lote; i++)
            Sumidouro<TResultado>.Valor = executar(entrada);
        return Stopwatch.GetElapsedTime(inicio).TotalSeconds;
    }

    // Entrada recriada a cada chamada: só o tempo da solução entra na conta (a criação fica de fora).
    private static double MedirRecriando<TEntrada, TResultado>(
        int n, Func<int, TEntrada> criarEntrada, Func<TEntrada, TResultado> executar)
    {
        double melhor = double.MaxValue;
        for (int r = 0; r < Rodadas; r++)
        {
            long ticks = 0, chamadas = 0;
            long inicioRodada = Stopwatch.GetTimestamp();
            do
            {
                var entrada = criarEntrada(n);
                long inicio = Stopwatch.GetTimestamp();
                Sumidouro<TResultado>.Valor = executar(entrada);
                ticks += Stopwatch.GetTimestamp() - inicio;
                chamadas++;
            }
            while ((double)ticks / Stopwatch.Frequency < AlvoPorMedicao.TotalSeconds
                   && Stopwatch.GetElapsedTime(inicioRodada) < AlvoPorMedicao * 20);

            melhor = Math.Min(melhor, (double)ticks / Stopwatch.Frequency / chamadas);
        }
        return melhor;
    }

    // Guarda o resultado para o JIT não "otimizar fora" a chamada da solução.
    private static class Sumidouro<T>
    {
        public static T? Valor;
    }
}

/// <summary>Tempo médio de uma chamada para um tamanho n.</summary>
public sealed record PontoMedicao(int N, double SegundosPorChamada);

/// <summary>Resultado da medição: pontos, expoente estimado e a classe de complexidade.</summary>
public sealed class MedicaoDeComplexidade
{
    public IReadOnlyList<PontoMedicao> Pontos { get; }

    /// <summary>Expoente k de tempo ≈ c · nᵏ.</summary>
    public double Expoente { get; }

    public ComplexidadeDeTempo Classificacao { get; }

    private readonly bool _comDebugger;

    internal MedicaoDeComplexidade(List<PontoMedicao> pontos, bool comDebugger)
    {
        Pontos = pontos;
        _comDebugger = comDebugger;
        Expoente = CalcularExpoente(pontos);
        Classificacao = Expoente switch
        {
            < 0.5 => ComplexidadeDeTempo.ConstanteOuLogaritmica,
            < 1.5 => ComplexidadeDeTempo.Linear,
            < 2.5 => ComplexidadeDeTempo.Quadratica,
            _ => ComplexidadeDeTempo.CubicaOuPior,
        };
    }

    // Inclinação de ln(tempo) x ln(n) pelo estimador de Theil-Sen: a MEDIANA das inclinações entre
    // todos os pares de pontos. Um ponto fora da curva (GC, outro processo...) quase não afeta o resultado.
    private static double CalcularExpoente(IReadOnlyList<PontoMedicao> pontos)
    {
        var inclinacoes = new List<double>();
        for (int i = 0; i < pontos.Count; i++)
        {
            for (int j = i + 1; j < pontos.Count; j++)
            {
                inclinacoes.Add(
                    Math.Log(pontos[j].SegundosPorChamada / pontos[i].SegundosPorChamada)
                    / Math.Log((double)pontos[j].N / pontos[i].N));
            }
        }

        inclinacoes.Sort();
        int meio = inclinacoes.Count / 2;
        return inclinacoes.Count % 2 == 1
            ? inclinacoes[meio]
            : (inclinacoes[meio - 1] + inclinacoes[meio]) / 2;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Complexidade de tempo: {Complexidade.Descrever(Classificacao)}   (expoente ≈ {Expoente:0.00})");
        sb.AppendLine();
        sb.AppendLine("         n | tempo por chamada | ao dobrar n, o tempo...");
        sb.AppendLine("-----------+-------------------+------------------------");
        for (int i = 0; i < Pontos.Count; i++)
        {
            var p = Pontos[i];
            var fator = "";
            if (i > 0)
            {
                var anterior = Pontos[i - 1];
                // normaliza para "por dobra" mesmo se os tamanhos não forem potências de 2
                var porDobra = Math.Pow(
                    p.SegundosPorChamada / anterior.SegundosPorChamada,
                    Math.Log(2) / Math.Log((double)p.N / anterior.N));
                fator = $"x{porDobra:0.0}";
            }
            sb.AppendLine($"{p.N,10:N0} | {Formatar(p.SegundosPorChamada),17} | {fator}");
        }
        sb.AppendLine();
        sb.Append("Regra de bolso (ao dobrar n): x1 = O(1)/O(log n) · x2 = O(n) · x4 = O(n²) · x8 = O(n³)");

        if (_comDebugger)
        {
            sb.AppendLine();
            sb.Append("Atenção: rodou com o debugger anexado ('Debug Tests'). Para números mais confiáveis, use 'Run Tests'.");
        }

        return sb.ToString();
    }

    private static string Formatar(double segundos) => segundos switch
    {
        < 1e-6 => $"{segundos * 1e9:0.0} ns",
        < 1e-3 => $"{segundos * 1e6:0.00} µs",
        < 1 => $"{segundos * 1e3:0.00} ms",
        _ => $"{segundos:0.00} s",
    };
}
