namespace LeetCode.Easy.Exercicios;

public class Ex03_RomanToInteger
{
    /// <summary>
    /// <b>13. Roman to Integer</b> (Fácil) — https://leetcode.com/problems/roman-to-integer/
    /// <para>
    /// Converta um número romano (string <c>s</c>) para inteiro.
    /// Símbolos: I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000.
    /// </para>
    /// <para>
    /// Normalmente os símbolos vêm do maior para o menor e são somados (XII = 10 + 1 + 1 = 12).
    /// A exceção é a subtração: quando um símbolo menor aparece ANTES de um maior, ele é subtraído.
    /// Os seis casos possíveis são: IV = 4, IX = 9, XL = 40, XC = 90, CD = 400, CM = 900.
    /// </para>
    /// <para>
    /// Exemplo 1: s = "III"      →  3
    /// Exemplo 2: s = "LVIII"    →  58    (L = 50, V = 5, III = 3)
    /// Exemplo 3: s = "MCMXCIV"  →  1994  (M = 1000, CM = 900, XC = 90, IV = 4)
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ s.Length ≤ 15 · s contém apenas I, V, X, L, C, D, M · s é sempre um romano válido entre 1 e 3999.
    /// </para>
    /// </summary>
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XL", 40)]
    [InlineData("XC", 90)]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    [InlineData("MMXXVI", 2026)]
    [InlineData("MMMCMXCIX", 3999)]
    public void RomanToInt_DeveConverterRomanoParaInteiro(string s, int esperado)
    {
        var resultado = RomanToInt(s);

        Assert.Equal(esperado, resultado);
    }

    // TODO: implemente sua solução aqui
    public int RomanToInt(string s)
    {
        throw new NotImplementedException();
    }
}
