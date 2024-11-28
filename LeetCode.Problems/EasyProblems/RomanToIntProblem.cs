namespace LeetCode.Problems.EasyProblems
{
    public class RomanToIntProblem
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanNumbers = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int result = 0;

            foreach (var letter in s.ToCharArray())
            {
                if (romanNumbers.ContainsKey(letter))
                {
                    var value = romanNumbers[letter];

                    result += value;
                }
            }

            return result;
        }
    }
}
