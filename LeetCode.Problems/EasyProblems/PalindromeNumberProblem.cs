namespace LeetCode.Problems.EasyProblems
{
    public class PalindromeNumberProblem
    {
        public bool IsPalindrome(int number)
        {
            var numbers = number.ToString().Select(d => d.ToString()).ToArray();

            string newNumber = string.Empty;

            for (int i = (numbers.Length - 1); i >= 0; i--)
                newNumber += numbers[i];

            if (!int.TryParse(newNumber, out int newInt))
                return false;

            return newInt == number;
        }
    }
}
