namespace LeetCode.Easy.Exercicios;

public class Ex04_LongestCommonPrefix
{
    /// <summary>
    /// <b>14. Longest Common Prefix</b> (Fácil) — https://leetcode.com/problems/longest-common-prefix/
    /// <para>
    /// Escreva uma função que encontre o maior prefixo comum entre todas as strings do array <c>strs</c>.
    /// Se não houver prefixo comum, retorne a string vazia "".
    /// </para>
    /// <para>
    /// Exemplo 1: strs = ["flower","flow","flight"]  →  "fl"
    /// Exemplo 2: strs = ["dog","racecar","car"]     →  ""   (não há prefixo comum)
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ strs.Length ≤ 200 · 0 ≤ strs[i].Length ≤ 200 · strs[i] contém apenas letras minúsculas.
    /// </para>
    /// </summary>
    [Theory]
    [InlineData(new[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new[] { "dog", "racecar", "car" }, "")]
    [InlineData(new[] { "a" }, "a")]
    [InlineData(new[] { "", "b" }, "")]
    [InlineData(new[] { "ab", "a" }, "a")]
    [InlineData(new[] { "cir", "car" }, "c")]
    [InlineData(new[] { "interspecies", "interstellar", "interstate" }, "inters")]
    [InlineData(new[] { "igual", "igual", "igual" }, "igual")]
    public void LongestCommonPrefix_DeveRetornarOMaiorPrefixoComum(string[] strs, string esperado)
    {
        var resultado = LongestCommonPrefix(strs);

        Assert.Equal(esperado, resultado);
    }

    // TODO: implemente sua solução aqui
    public string LongestCommonPrefix(string[] strs)
    {
        throw new NotImplementedException();
    }
}
