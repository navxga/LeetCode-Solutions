namespace LeetCode.Easy.Exercicios;

public class Ex04_LongestCommonPrefix
{
    /// <summary>
    /// <b>14. Longest Common Prefix</b> (Fácil) — https://leetcode.com/problems/longest-common-prefix/
    /// <para>
    /// Escreva uma função que encontre o maior prefixo comum entre todas as strings do array <c>words</c>.
    /// Se não houver prefixo comum, retorne a string vazia "".
    /// </para>
    /// <para>
    /// Exemplo 1: words = ["flower","flow","flight"]  →  "fl"
    /// Exemplo 2: words = ["dog","racecar","car"]     →  ""   (não há prefixo comum)
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ words.Length ≤ 200 · 0 ≤ words[i].Length ≤ 200 · words[i] contém apenas letras minúsculas.
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
    public void LongestCommonPrefix_DeveRetornarOMaiorPrefixoComum(string[] words, string esperado)
    {
        var resultado = LongestCommonPrefix(words);

        Assert.Equal(esperado, resultado);
    }

    public string LongestCommonPrefix(string[] words)
    {
        char[] letters = words[0].ToCharArray();
        string prefix = string.Empty;

        for (int i = 0; i < letters.Length; i++)
        {
            if (words.Any(w => !w.StartsWith(prefix + letters[i])))
                break;

            prefix += letters[i];
        }

        return prefix;
    }
}
