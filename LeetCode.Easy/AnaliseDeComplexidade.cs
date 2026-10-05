using LeetCode.Easy.Exercicios;

namespace LeetCode.Easy;

/// <summary>Exercícios que a análise de complexidade sabe medir.</summary>
public enum Exercicio
{
    Ex01_TwoSum,
    Ex02_PalindromeNumber,
    Ex03_RomanToInteger,
    Ex04_LongestCommonPrefix,
    Ex05_ValidParentheses,
    Ex06_MergeTwoSortedLists,
    Ex07_RemoveDuplicatesFromSortedArray,
    Ex08_RemoveElement,
    Ex09_FirstOccurrenceInString,
    Ex10_SearchInsertPosition,
}

public class AnaliseDeComplexidade
{
    /// <summary>
    /// Classifica a complexidade de tempo (Big-O) da SUA solução atual do exercício escolhido.
    /// Não existe "certo" ou "errado" aqui: o teste só mede e diz em qual classe a solução caiu.
    /// <para>
    /// Como usar: no Test Explorer, expanda "Classificar" e rode a linha do exercício que quiser (ou todas).
    /// Clique na linha para ver o resultado no painel de detalhes do teste, por exemplo:
    /// "Complexidade de tempo: O(n²), quadrática", seguido da tabela de tempos por tamanho de entrada.
    /// </para>
    /// <para>
    /// Exercício ainda não implementado (NotImplementedException) aparece como Skipped.
    /// </para>
    /// </summary>
    [Theory]
    [InlineData(Exercicio.Ex01_TwoSum)]
    [InlineData(Exercicio.Ex02_PalindromeNumber)]
    [InlineData(Exercicio.Ex03_RomanToInteger)]
    [InlineData(Exercicio.Ex04_LongestCommonPrefix)]
    [InlineData(Exercicio.Ex05_ValidParentheses)]
    [InlineData(Exercicio.Ex06_MergeTwoSortedLists)]
    [InlineData(Exercicio.Ex07_RemoveDuplicatesFromSortedArray)]
    [InlineData(Exercicio.Ex08_RemoveElement)]
    [InlineData(Exercicio.Ex09_FirstOccurrenceInString)]
    [InlineData(Exercicio.Ex10_SearchInsertPosition)]
    public void Classificar(Exercicio exercicio)
    {
        if (exercicio == Exercicio.Ex02_PalindromeNumber)
            Assert.Skip("A entrada é um único int (no máximo 10 dígitos), então não dá para fazer n crescer e medir.");

        MedicaoDeComplexidade medicao;
        try
        {
            medicao = Medir(exercicio);
        }
        catch (NotImplementedException)
        {
            Assert.Skip($"{exercicio} ainda não foi implementado.");
            throw; // nunca chega aqui: o Assert.Skip interrompe o teste
        }

        var saida = TestContext.Current.TestOutputHelper;
        saida?.WriteLine(exercicio.ToString());
        saida?.WriteLine(medicao.ToString());
    }

    private static MedicaoDeComplexidade Medir(Exercicio exercicio) => exercicio switch
    {
        Exercicio.Ex01_TwoSum => MedirTwoSum(),
        Exercicio.Ex03_RomanToInteger => MedirRomanToInt(),
        Exercicio.Ex04_LongestCommonPrefix => MedirLongestCommonPrefix(),
        Exercicio.Ex05_ValidParentheses => MedirValidParentheses(),
        Exercicio.Ex06_MergeTwoSortedLists => MedirMergeTwoSortedLists(),
        Exercicio.Ex07_RemoveDuplicatesFromSortedArray => MedirRemoveDuplicates(),
        Exercicio.Ex08_RemoveElement => MedirRemoveElement(),
        Exercicio.Ex09_FirstOccurrenceInString => MedirStrStr(),
        Exercicio.Ex10_SearchInsertPosition => MedirSearchInsert(),
        _ => throw new ArgumentOutOfRangeException(nameof(exercicio), exercicio, "Exercício sem gerador de pior caso."),
    };

    // ------------------------------------------------------------------------------------------
    // Um método por exercício: gera a entrada de PIOR CASO de tamanho n e chama a sua solução.
    // A entrada precisa ser de pior caso; se a resposta estiver logo no começo, qualquer solução termina rápido.
    // ------------------------------------------------------------------------------------------

    // O único par que soma o target fica no MEIO do array, então quem testa par a par
    // (em qualquer direção) precisa passar por uma boa parte dos n² pares.
    private static MedicaoDeComplexidade MedirTwoSum()
    {
        var solucao = new Ex01_TwoSum();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var nums = new int[n];
                for (int i = 0; i < n; i++)
                    nums[i] = i * 2;     // só pares não-negativos: nenhuma dupla deles soma -3
                nums[n / 2 - 1] = -1;    // a única resposta: -1 + -2 = -3
                nums[n / 2] = -2;
                return (nums, target: -3);
            },
            executar: e => solucao.TwoSum(e.nums, e.target));
    }

    // String de tamanho n só com casos de subtração ("CMCMCM..."). Passa do limite de 15 caracteres
    // do LeetCode de propósito, para dar para ver o crescimento.
    private static MedicaoDeComplexidade MedirRomanToInt()
    {
        var solucao = new Ex03_RomanToInteger();
        return Complexidade.Medir(
            criarEntrada: n => string.Concat(Enumerable.Repeat("CM", n / 2)),
            executar: s => solucao.RomanToInt(s));
    }

    // 3 strings idênticas de tamanho n: o prefixo comum é a string inteira.
    private static MedicaoDeComplexidade MedirLongestCommonPrefix()
    {
        var solucao = new Ex04_LongestCommonPrefix();
        return Complexidade.Medir(
            criarEntrada: n => new[] { new string('a', n), new string('a', n), new string('a', n) },
            executar: strs => solucao.LongestCommonPrefix(strs));
    }

    // Aninhamento profundo e válido: "([{([{ ... }])}])".
    private static MedicaoDeComplexidade MedirValidParentheses()
    {
        var solucao = new Ex05_ValidParentheses();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var c = new char[n];
                for (int i = 0; i < n / 2; i++)
                {
                    c[i] = "([{"[i % 3];
                    c[n - 1 - i] = ")]}"[i % 3];
                }
                return new string(c);
            },
            executar: s => solucao.IsValid(s));
    }

    // Listas intercaladas (pares x ímpares): o merge precisa alternar entre as duas o tempo todo.
    // Tamanhos menores que o padrão para não estourar a pilha em soluções recursivas (profundidade = n).
    private static MedicaoDeComplexidade MedirMergeTwoSortedLists()
    {
        var solucao = new Ex06_MergeTwoSortedLists();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var pares = new int[n / 2];
                var impares = new int[n / 2];
                for (int i = 0; i < n / 2; i++)
                {
                    pares[i] = 2 * i;
                    impares[i] = 2 * i + 1;
                }
                return (list1: ListNode.FromArray(pares), list2: ListNode.FromArray(impares));
            },
            executar: e => solucao.MergeTwoLists(e.list1, e.list2),
            recriarEntradaACadaExecucao: true, // o merge reencadeia os nós
            tamanhos: [200, 400, 800, 1_600, 3_200]);
    }

    // Metade dos elementos são duplicados, espalhados pelo array: [0,0,1,1,2,2,...].
    private static MedicaoDeComplexidade MedirRemoveDuplicates()
    {
        var solucao = new Ex07_RemoveDuplicatesFromSortedArray();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var nums = new int[n];
                for (int i = 0; i < n; i++)
                    nums[i] = i / 2;
                return nums;
            },
            executar: nums => solucao.RemoveDuplicates(nums),
            recriarEntradaACadaExecucao: true); // in-place
    }

    // O valor a remover ocupa metade das posições, intercalado: [3,1,3,1,...], val = 3.
    private static MedicaoDeComplexidade MedirRemoveElement()
    {
        var solucao = new Ex08_RemoveElement();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var nums = new int[n];
                for (int i = 0; i < n; i++)
                    nums[i] = i % 2 == 0 ? 3 : 1;
                return nums;
            },
            executar: nums => solucao.RemoveElement(nums, 3),
            recriarEntradaACadaExecucao: true); // in-place
    }

    // haystack = "aaaa...a" e needle = "aaa...ab" (metade do tamanho): a comparação
    // quase casa em toda posição e só falha no último caractere.
    private static MedicaoDeComplexidade MedirStrStr()
    {
        var solucao = new Ex09_FirstOccurrenceInString();
        return Complexidade.Medir(
            criarEntrada: n => (haystack: new string('a', n), needle: new string('a', n / 2) + "b"),
            executar: e => solucao.StrStr(e.haystack, e.needle));
    }

    // target ausente e no meio do array (nem no começo, nem no fim).
    private static MedicaoDeComplexidade MedirSearchInsert()
    {
        var solucao = new Ex10_SearchInsertPosition();
        return Complexidade.Medir(
            criarEntrada: n =>
            {
                var nums = new int[n];
                for (int i = 0; i < n; i++)
                    nums[i] = i * 2;
                return (nums, target: n + 1);
            },
            executar: e => solucao.SearchInsert(e.nums, e.target));
    }
}
