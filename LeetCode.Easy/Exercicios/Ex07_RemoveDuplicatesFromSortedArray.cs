namespace LeetCode.Easy.Exercicios;

public class Ex07_RemoveDuplicatesFromSortedArray
{
    /// <summary>
    /// <b>26. Remove Duplicates from Sorted Array</b> (Fácil) — https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    /// <para>
    /// Dado um array <c>nums</c> ordenado em ordem crescente, remova os duplicados IN-PLACE
    /// (no próprio array, sem criar outro) de forma que cada elemento apareça só uma vez,
    /// mantendo a ordem relativa. Retorne <c>k</c> = quantidade de elementos únicos.
    /// </para>
    /// <para>
    /// Para ser aceito: os primeiros <c>k</c> elementos de <c>nums</c> devem ser os valores únicos,
    /// na ordem original. O que sobrar depois da posição k não importa.
    /// </para>
    /// <para>
    /// Exemplo 1: nums = [1,1,2]                →  k = 2, nums = [1,2,_]
    /// Exemplo 2: nums = [0,0,1,1,1,2,2,3,3,4]  →  k = 5, nums = [0,1,2,3,4,_,_,_,_,_]
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ nums.Length ≤ 3·10⁴ · -100 ≤ nums[i] ≤ 100 · nums está ordenado em ordem não-decrescente.
    /// </para>
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [InlineData(new[] { -3, -3, -3 }, new[] { -3 })]
    [InlineData(new[] { -1, 0, 0, 0, 0, 3, 3 }, new[] { -1, 0, 3 })]
    public void RemoveDuplicates_DeveManterApenasValoresUnicosNoInicio(int[] nums, int[] esperado)
    {
        var k = RemoveDuplicates(nums);

        Assert.Equal(esperado.Length, k);
        Assert.Equal(esperado, nums[..k]); // só os k primeiros importam
    }

    // TODO: implemente sua solução aqui
    public int RemoveDuplicates(int[] nums)
    {
        throw new NotImplementedException();
    }
}
