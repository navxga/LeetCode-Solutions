namespace LeetCode.Easy.Common;

/// <summary>
/// Nó de lista ligada simples — mesma definição usada pelo LeetCode
/// (campos <c>val</c> e <c>next</c> em minúsculo para você poder colar a solução lá sem ajustes).
/// </summary>
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;

    /// <summary>Monta uma lista ligada a partir de um array. Array vazio vira <c>null</c>.</summary>
    public static ListNode? FromArray(int[] values)
    {
        ListNode? head = null;
        for (int i = values.Length - 1; i >= 0; i--)
            head = new ListNode(values[i], head);
        return head;
    }

    /// <summary>Converte a lista ligada em array (com proteção contra ciclos acidentais).</summary>
    public static int[] ToArray(ListNode? head)
    {
        const int limite = 10_000;
        var result = new List<int>();
        for (var node = head; node is not null; node = node.next)
        {
            if (result.Count >= limite)
                throw new InvalidOperationException(
                    $"A lista tem mais de {limite} nós — provavelmente existe um ciclo (algum 'next' apontando para trás).");
            result.Add(node.val);
        }
        return [.. result];
    }
}
