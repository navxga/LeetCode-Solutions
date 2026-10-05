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
    ├── Common/
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
