namespace LeetCode.Easy.Exercicios;

public class Ex02_PalindromeNumber
{
    /// <summary>
    /// <b>9. Palindrome Number</b> (Fácil) — https://leetcode.com/problems/palindrome-number/
    /// <para>
    /// Dado um inteiro <c>x</c>, retorne <c>true</c> se ele for um palíndromo
    /// (lido da esquerda para a direita é igual a lido da direita para a esquerda)
    /// e <c>false</c> caso contrário.
    /// </para>
    /// <para>
    /// Exemplo 1: x = 121   →  true
    /// Exemplo 2: x = -121  →  false  (de trás pra frente fica "121-")
    /// Exemplo 3: x = 10    →  false  (de trás pra frente fica "01")
    /// </para>
    /// <para>Restrições: -2³¹ ≤ x ≤ 2³¹ - 1</para>
    /// <para>Follow-up: consegue resolver SEM converter o número para string?</para>
    /// </summary>
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    [InlineData(0, true)]
    [InlineData(7, true)]
    [InlineData(1221, true)]
    [InlineData(12321, true)]
    [InlineData(123, false)]
    [InlineData(1000021, false)]
    [InlineData(2147447412, true)]
    [InlineData(int.MaxValue, false)]
    public void IsPalindrome_DeveIdentificarPalindromos(int x, bool esperado)
    {
        var resultado = IsPalindrome(x);

        Assert.Equal(esperado, resultado);
    }

    public bool IsPalindrome(int x)
    {
        char[] nums = x.ToString().ToCharArray();

        for (int i = 0; i < nums.Length / 2; i++)
        {
            int j = nums.Length - (i + 1);

            if (nums[i] != nums[j])
                return false;
        }

        return true;
    }
}
