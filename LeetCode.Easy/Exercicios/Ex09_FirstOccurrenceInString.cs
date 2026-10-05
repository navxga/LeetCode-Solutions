namespace LeetCode.Easy.Exercicios;

public class Ex09_FirstOccurrenceInString
{
    /// <summary>
    /// <b>28. Find the Index of the First Occurrence in a String</b> (Fácil) — https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
    /// <para>
    /// Dadas duas strings <c>haystack</c> e <c>needle</c>, retorne o índice da primeira ocorrência
    /// de <c>needle</c> dentro de <c>haystack</c>, ou -1 se <c>needle</c> não fizer parte de <c>haystack</c>.
    /// </para>
    /// <para>
    /// Exemplo 1: haystack = "sadbutsad", needle = "sad"    →  0   (aparece nos índices 0 e 6; o primeiro é 0)
    /// Exemplo 2: haystack = "leetcode",  needle = "leeto"  →  -1
    /// </para>
    /// <para>
    /// Restrições: 1 ≤ haystack.Length, needle.Length ≤ 10⁴ · ambas contêm apenas letras minúsculas.
    /// </para>
    /// <para>Desafio: resolva sem usar haystack.IndexOf(needle)</para>
    /// </summary>
    [Theory]
    [InlineData("sadbutsad", "sad", 0)]
    [InlineData("leetcode", "leeto", -1)]
    [InlineData("hello", "ll", 2)]
    [InlineData("aaaaa", "bba", -1)]
    [InlineData("mississippi", "issip", 4)]
    [InlineData("mississippi", "pi", 9)]
    [InlineData("a", "a", 0)]
    [InlineData("abc", "c", 2)]
    [InlineData("abc", "abcd", -1)]
    public void StrStr_DeveRetornarOIndiceDaPrimeiraOcorrencia(string haystack, string needle, int esperado)
    {
        var resultado = StrStr(haystack, needle);

        Assert.Equal(esperado, resultado);
    }

    // TODO: implemente sua solução aqui
    public int StrStr(string haystack, string needle)
    {
        throw new NotImplementedException();
    }
}
