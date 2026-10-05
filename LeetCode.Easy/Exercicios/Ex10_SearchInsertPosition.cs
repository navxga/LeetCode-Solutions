namespace LeetCode.Easy.Exercicios;

public class Ex10_SearchInsertPosition
{
    /// <summary>
    /// <b>35. Search Insert Position</b> (Fácil) — https://leetcode.com/problems/search-insert-position/
    /// <para>
    /// Dado um array ordenado de inteiros DISTINTOS <c>nums</c> e um valor <c>target</c>, retorne o índice
    /// de <c>target</c> se ele existir. Se não existir, retorne o índice onde ele deveria ser inserido
    /// para manter o array ordenado.
    /// </para>
    /// <para>
    /// Exemplo 1: nums = [1,3,5,6], target = 5  →  2
    /// Exemplo 2: nums = [1,3,5,6], target = 2  →  1
    /// Exemplo 3: nums = [1,3,5,6], target = 7  →  4
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ nums.Length ≤ 10⁴ · -10⁴ ≤ nums[i], target ≤ 10⁴ · nums tem valores distintos em ordem crescente.
    /// </para>
    /// <para>Obrigatório (no LeetCode): o algoritmo deve ser O(log n) — pense em busca binária.</para>
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
    [InlineData(new[] { 1, 3, 5, 6 }, 0, 0)]
    [InlineData(new[] { 1 }, 1, 0)]
    [InlineData(new[] { 1 }, 0, 0)]
    [InlineData(new[] { 1 }, 2, 1)]
    [InlineData(new[] { -5, -2, 0, 4, 9 }, 3, 3)]
    public void SearchInsert_DeveRetornarAPosicaoCorreta(int[] nums, int target, int esperado)
    {
        var resultado = SearchInsert(nums, target);

        Assert.Equal(esperado, resultado);
    }

    // TODO: implemente sua solução aqui
    public int SearchInsert(int[] nums, int target)
    {
        throw new NotImplementedException();
    }
}
