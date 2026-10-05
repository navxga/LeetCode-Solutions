namespace LeetCode.Easy.Exercicios;

public class Ex01_TwoSum
{
    /// <summary>
    /// <b>1. Two Sum</b> (Fácil) — https://leetcode.com/problems/two-sum/
    /// <para>
    /// Dado um array de inteiros <c>nums</c> e um inteiro <c>target</c>, retorne os ÍNDICES
    /// dos dois números cuja soma é igual a <c>target</c>.
    /// Toda entrada tem exatamente uma solução e você não pode usar o mesmo elemento duas vezes.
    /// A resposta pode ser retornada em qualquer ordem.
    /// </para>
    /// <para>
    /// Exemplo 1: nums = [2,7,11,15], target = 9  →  [0,1]   (nums[0] + nums[1] == 9)
    /// Exemplo 2: nums = [3,2,4],     target = 6  →  [1,2]
    /// Exemplo 3: nums = [3,3],       target = 6  →  [0,1]
    /// </para>
    /// <para>
    /// Restrições: 2 ≤ nums.Length ≤ 10⁴ · -10⁹ ≤ nums[i] ≤ 10⁹ · -10⁹ ≤ target ≤ 10⁹ · só existe uma resposta válida.
    /// </para>
    /// <para>Follow-up: consegue um algoritmo melhor que O(n²)?</para>
    /// </summary>
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    [InlineData(new[] { -1, -2, -3, -4, -5 }, -8, new[] { 2, 4 })]
    [InlineData(new[] { 0, 4, 3, 0 }, 0, new[] { 0, 3 })]
    public void TwoSum_DeveRetornarOsIndicesDosDoisNumeros(int[] nums, int target, int[] esperado)
    {
        var resultado = TwoSum(nums, target);

        Assert.NotNull(resultado);
        Assert.Equal(esperado, resultado.Order().ToArray()); // a ordem não importa
    }

    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j)
                    continue;

                bool isEqual = nums[i] + nums[j] == target;

                if (isEqual)
                    return [ i, j ];
            }
        }

        return [];
    }
}
