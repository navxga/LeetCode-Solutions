using LeetCode.Easy.Common;

namespace LeetCode.Easy.Exercicios;

public class Ex06_MergeTwoSortedLists
{
    /// <summary>
    /// <b>21. Merge Two Sorted Lists</b> (Fácil) — https://leetcode.com/problems/merge-two-sorted-lists/
    /// <para>
    /// Você recebe o início (head) de duas listas ligadas, <c>list1</c> e <c>list2</c>, ambas ordenadas
    /// em ordem crescente. Junte as duas em uma única lista ordenada, reaproveitando os nós das listas
    /// originais (encadeando-os), e retorne o head da lista resultante.
    /// </para>
    /// <para>
    /// Exemplo 1: list1 = [1,2,4], list2 = [1,3,4]  →  [1,1,2,3,4,4]
    /// Exemplo 2: list1 = [],      list2 = []       →  []
    /// Exemplo 3: list1 = [],      list2 = [0]      →  [0]
    /// </para>
    /// <para>
    /// Restrições: cada lista tem de 0 a 50 nós · -100 ≤ Node.val ≤ 100 · as duas listas já vêm ordenadas.
    /// </para>
    /// <para>
    /// Dica: a classe <see cref="ListNode"/> fica em Common/ListNode.cs.
    /// Nos testes, os arrays são convertidos em listas ligadas para você.
    /// </para>
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new int[] { }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 5 }, new[] { 1, 2, 4 }, new[] { 1, 2, 4, 5 })]
    [InlineData(new[] { -3, 0, 7 }, new[] { -5, 10 }, new[] { -5, -3, 0, 7, 10 })]
    [InlineData(new[] { 1, 1, 1 }, new[] { 1, 1 }, new[] { 1, 1, 1, 1, 1 })]
    public void MergeTwoLists_DeveJuntarAsListasOrdenadas(int[] lista1, int[] lista2, int[] esperado)
    {
        var list1 = ListNode.FromArray(lista1);
        var list2 = ListNode.FromArray(lista2);

        var resultado = MergeTwoLists(list1, list2);

        Assert.Equal(esperado, ListNode.ToArray(resultado));
    }

    // TODO: implemente sua solução aqui
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        throw new NotImplementedException();
    }
}
