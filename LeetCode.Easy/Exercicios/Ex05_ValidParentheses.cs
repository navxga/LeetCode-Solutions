namespace LeetCode.Easy.Exercicios;

public class Ex05_ValidParentheses
{
    /// <summary>
    /// <b>20. Valid Parentheses</b> (Fácil) — https://leetcode.com/problems/valid-parentheses/
    /// <para>
    /// Dada uma string <c>s</c> contendo apenas os caracteres '(', ')', '{', '}', '[' e ']',
    /// determine se ela é válida. Uma string é válida quando:
    /// (1) todo símbolo aberto é fechado pelo mesmo tipo de símbolo;
    /// (2) os símbolos são fechados na ordem correta;
    /// (3) todo símbolo de fechamento tem um de abertura correspondente.
    /// </para>
    /// <para>
    /// Exemplo 1: s = "()"      →  true
    /// Exemplo 2: s = "()[]{}"  →  true
    /// Exemplo 3: s = "(]"      →  false
    /// Exemplo 4: s = "([])"    →  true
    /// Exemplo 5: s = "([)]"    →  false
    /// </para>
    /// <para>Restrições: 1 ≤ s.Length ≤ 10⁴ · s contém apenas ()[]{}</para>
    /// </summary>
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([])", true)]
    [InlineData("([)]", false)]
    [InlineData("{[]}", true)]
    [InlineData("((()))[{}]", true)]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("((", false)]
    [InlineData("){", false)]
    [InlineData("(()", false)]
    public void IsValid_DeveValidarParenteses(string s, bool esperado)
    {
        var resultado = IsValid(s);

        Assert.Equal(esperado, resultado);
    }

    // TODO: implemente sua solução aqui
    public bool IsValid(string s)
    {
        throw new NotImplementedException();
    }
}
