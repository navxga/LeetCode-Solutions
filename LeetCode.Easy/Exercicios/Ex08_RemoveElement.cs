namespace LeetCode.Easy.Exercicios;

public class Ex08_RemoveElement
{
    /// <summary>
    /// <b>27. Remove Element</b> (Fácil) — https://leetcode.com/problems/remove-element/
    /// <para>
    /// Dado um array <c>nums</c> e um valor <c>val</c>, remova IN-PLACE todas as ocorrências de <c>val</c>.
    /// A ordem dos elementos pode mudar. Retorne <c>k</c> = quantidade de elementos diferentes de <c>val</c>.
    /// </para>
    /// <para>
    /// Para ser aceito: os primeiros <c>k</c> elementos de <c>nums</c> devem ser os elementos que não são
    /// iguais a <c>val</c> (em qualquer ordem). O que sobrar depois da posição k não importa.
    /// </para>
    /// <para>
    /// Exemplo 1: nums = [3,2,2,3],         val = 3  →  k = 2, nums = [2,2,_,_]
    /// Exemplo 2: nums = [0,1,2,2,3,0,4,2], val = 2  →  k = 5, nums = [0,1,4,0,3,_,_,_] (qualquer ordem)
    /// </para>
    /// <para>
    /// Restrições: 0 ≤ nums.Length ≤ 100 · 0 ≤ nums[i] ≤ 50 · 0 ≤ val ≤ 100
    /// </para>
    /// </summary>
    [Theory]
    [InlineData(new[] { 3, 2, 2, 3 }, 3, new[] { 2, 2 })]
    [InlineData(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new[] { 0, 0, 1, 3, 4 })]
    [InlineData(new int[] { }, 0, new int[] { })]
    [InlineData(new[] { 1 }, 1, new int[] { })]
    [InlineData(new[] { 4, 5 }, 4, new[] { 5 })]
    [InlineData(new[] { 2, 2, 2 }, 3, new[] { 2, 2, 2 })]
    public void RemoveElement_DeveRemoverTodasAsOcorrencias(int[] nums, int val, int[] esperado)
    {
        var k = RemoveElement(nums, val);

        Assert.Equal(esperado.Length, k);

        // A ordem não importa: ordena os k primeiros antes de comparar ('esperado' já está ordenado)
        var primeirosK = nums[..k];
        Array.Sort(primeirosK);
        Assert.Equal(esperado, primeirosK);
    }

    // TODO: implemente sua solução aqui
    public int RemoveElement(int[] nums, int val)
    {
        throw new NotImplementedException();
    }
}
