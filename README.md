# LeetCode em C# (.NET 10)

Os 10 primeiros exercícios **Easy** do LeetCode (em ordem de número), prontos para resolver no Visual Studio, sem precisar codar no navegador.

Cada exercício é **uma classe de teste**: a descrição fica no `/// <summary>` em cima do teste, os casos de teste já estão montados com o resultado esperado, e o método da solução está vazio (lançando `NotImplementedException`) esperando o seu código.

## Stack

| Item | Versão |
|---|---|
| .NET SDK | 10.0 (C# 14) |
| xUnit.net | v3 — `xunit.v3` 4.0.1 |
| Runner | Microsoft Testing Platform (+ VSTest como fallback) |
| Solution | `LeetCode.slnx` (formato novo de solution) |

## Como usar

1. Abra `LeetCode.slnx` no Visual Studio 2026.
2. Abra o **Test Explorer** (`Ctrl + E, T`). Todos os testes vão aparecer falhando com `NotImplementedException`. É o esperado.
3. Abra um exercício (ex.: `Exercicios/Ex01_TwoSum.cs`), leia o enunciado no summary e implemente o método marcado com `// TODO`.
4. Clique no ícone de rodar ao lado do teste (ou `Ctrl + R, T` com o cursor dentro da classe). Ficou verde, passou.

> Os `// TODO` aparecem em **View > Task List**, então dá pra ver de cara quais exercícios ainda faltam.

### Pela linha de comando (opcional)

```bash
dotnet test                                                        # roda tudo
dotnet test --filter-class "LeetCode.Easy.Exercicios.Ex01_TwoSum"  # roda um exercício só
```

## Estrutura

```
LeetCode/
├── LeetCode.slnx
├── global.json               # fixa o SDK 10 e liga o Microsoft Testing Platform no dotnet test
├── README.md
└── LeetCode.Easy/
    ├── LeetCode.Easy.csproj
    ├── AnaliseDeComplexidade.cs  # classifica o Big-O da sua solução (veja abaixo)
    ├── Common/
    │   ├── Complexidade.cs   # motor de medição de Big-O
    │   └── ListNode.cs       # lista ligada (mesma definição do LeetCode) + helpers p/ os testes
    └── Exercicios/
        ├── Ex01_TwoSum.cs
        ├── ...
        └── Ex10_SearchInsertPosition.cs
```

## Exercícios

| # | LeetCode | Problema | Tópico | Arquivo | Feito |
|---|---|---|---|---|---|
| 01 | [1](https://leetcode.com/problems/two-sum/) | Two Sum | Array, Hash Table | `Ex01_TwoSum.cs` | [ ] |
| 02 | [9](https://leetcode.com/problems/palindrome-number/) | Palindrome Number | Math | `Ex02_PalindromeNumber.cs` | [ ] |
| 03 | [13](https://leetcode.com/problems/roman-to-integer/) | Roman to Integer | Hash Table, String | `Ex03_RomanToInteger.cs` | [ ] |
| 04 | [14](https://leetcode.com/problems/longest-common-prefix/) | Longest Common Prefix | String | `Ex04_LongestCommonPrefix.cs` | [ ] |
| 05 | [20](https://leetcode.com/problems/valid-parentheses/) | Valid Parentheses | Stack, String | `Ex05_ValidParentheses.cs` | [ ] |
| 06 | [21](https://leetcode.com/problems/merge-two-sorted-lists/) | Merge Two Sorted Lists | Linked List, Recursion | `Ex06_MergeTwoSortedLists.cs` | [ ] |
| 07 | [26](https://leetcode.com/problems/remove-duplicates-from-sorted-array/) | Remove Duplicates from Sorted Array | Array, Two Pointers | `Ex07_RemoveDuplicatesFromSortedArray.cs` | [ ] |
| 08 | [27](https://leetcode.com/problems/remove-element/) | Remove Element | Array, Two Pointers | `Ex08_RemoveElement.cs` | [ ] |
| 09 | [28](https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/) | Find the Index of the First Occurrence in a String | String, Two Pointers | `Ex09_FirstOccurrenceInString.cs` | [ ] |
| 10 | [35](https://leetcode.com/problems/search-insert-position/) | Search Insert Position | Array, Binary Search | `Ex10_SearchInsertPosition.cs` | [ ] |

Os casos de teste incluem os exemplos oficiais do enunciado e alguns casos extras de borda (arrays vazios, negativos, `int.MaxValue` etc.).

## Complexidade de tempo (Big-O)

O nome disso é **complexidade de tempo**, escrita em **notação Big-O** ("O grande"). Ela descreve como o tempo de execução cresce conforme o tamanho da entrada (`n`) cresce. Não tem a ver com a dificuldade do exercício (Easy/Medium/Hard): um Hard pode ter solução O(n) e um Easy pode ser resolvido em O(n²).

| Notação | Nome | Ao dobrar `n`, o tempo... |
|---|---|---|
| O(1) | constante | não muda |
| O(log n) | logarítmica | quase não muda |
| O(n) | linear | dobra |
| O(n log n) | linearítmica | um pouco mais que dobra |
| O(n²) | quadrática | multiplica por 4 |
| O(n³) | cúbica | multiplica por 8 |

### Classificando a sua solução

Tudo fica em um lugar só: `AnaliseDeComplexidade.cs`, na raiz do projeto. No Test Explorer, expanda **AnaliseDeComplexidade > Classificar** e rode a linha do exercício que quiser (ou todas). O teste não diz se está certo ou errado, só mede e classifica. Clique na linha para ver o resultado no painel de detalhes:

```
Ex01_TwoSum
Complexidade de tempo: O(n²), quadrática   (expoente ≈ 1,98)

         n | tempo por chamada | ao dobrar n, o tempo...
-----------+-------------------+------------------------
       500 |         180,00 µs |
     1.000 |         710,00 µs | x3,9
     2.000 |           2,85 ms | x4,0
     ...
```

Exercício ainda não implementado aparece como **Skipped**. O 02 (Palindrome Number) também, porque a entrada é um único `int` e não dá para fazer `n` crescer.

Como funciona (`Common/Complexidade.cs`): para cada exercício existe um gerador de entrada de **pior caso**. A análise roda a sua solução com `n` = 500, 1.000, 2.000, 4.000 e 8.000, mede o tempo por chamada (com aquecimento do JIT e o melhor de 5 rodadas) e calcula o expoente `k` da curva `tempo ≈ c · nᵏ`: `k≈0` → O(1)/O(log n), `k≈1` → O(n)/O(n log n), `k≈2` → O(n²).

Cuidados:

- É uma medição empírica: use **Run** (não Debug) e evite rodar com a máquina sobrecarregada. Se der um resultado estranho, rode de novo.
- Por medir tempo, não dá para separar O(1) de O(log n), nem O(n) de O(n log n).
- A análise não confere se a resposta está certa; quem faz isso são os testes de cada exercício.

### Incluindo um exercício novo na análise

Em `AnaliseDeComplexidade.cs`:

1. Adicione o exercício no `enum Exercicio` e uma linha `[InlineData(Exercicio.Ex11_...)]`.
2. Adicione o caso no `switch` do método `Medir`.
3. Crie o método com o gerador de pior caso:

```csharp
private static MedicaoDeComplexidade MedirNomeDoProblema()
{
    var solucao = new Ex11_NomeDoProblema();
    return Complexidade.Medir(
        criarEntrada: n => /* entrada de PIOR CASO com tamanho n */,
        executar: entrada => solucao.Metodo(entrada),
        recriarEntradaACadaExecucao: false); // true se a solução altera a entrada (in-place)
}
```

## Dicas

- A assinatura de cada método é igual à do LeetCode, então dá pra colar a solução direto lá para submeter.
- Exercícios "in-place" (07 e 08) só verificam os `k` primeiros elementos do array, como o próprio LeetCode faz.
- No 01 e no 08 a ordem da resposta não importa: o teste ordena antes de comparar.

## Adicionando um novo exercício

Crie um arquivo em `Exercicios/` seguindo o modelo:

```csharp
namespace LeetCode.Easy.Exercicios;

public class Ex11_NomeDoProblema
{
    /// <summary>
    /// <b>N. Nome do Problema</b> (Fácil) — https://leetcode.com/problems/...
    /// <para>Enunciado...</para>
    /// </summary>
    [Theory]
    [InlineData(/* entrada */, /* esperado */)]
    public void Metodo_DeveFazerAlgo(/* params */)
    {
        var resultado = Metodo(/* ... */);
        Assert.Equal(/* esperado */, resultado);
    }

    // TODO: implemente sua solução aqui
    public int Metodo(/* ... */)
    {
        throw new NotImplementedException();
    }
}
```
