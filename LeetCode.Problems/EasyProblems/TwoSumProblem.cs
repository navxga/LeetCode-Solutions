namespace LeetCode.Problems.EasyProblems
{
    public class TwoSumProblem
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = 0; j < nums.Count(); j++)
                {
                    var numA = nums[i];
                    var numB = nums[j];

                    if (numA + numB == target && i != j)
                        return new int[] { i, j };
                }
            }

            return null;
        }
    }
}
