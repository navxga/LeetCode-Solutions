using LeetCode.Problems.EasyProblems;

namespace LeetCode.Test.EasyProblems
{
    public class TwoSumProblemTest
    {
        private TwoSumProblem _problem;

        [SetUp]
        public void Setup()
        {
            _problem = new TwoSumProblem();
        }

        [Test]
        public void Case1()
        {
            var result = _problem.TwoSum(new int[] { 2, 7, 11, 15 }, 9);

            int[] solution = { 0, 1 };

            Assert.AreEqual(result, solution);
        }

        [Test]
        public void Case2()
        {
            var result = _problem.TwoSum(new int[] { 3, 2, 4 }, 6);

            int[] solution = { 1, 2 };

            Assert.IsTrue(result == solution);
        }

        [Test]
        public void Case3()
        {
            var result = _problem.TwoSum(new int[] { 3, 3 }, 6);

            int[] solution = { 0, 1 };

            Assert.IsTrue(result == solution);
        }
    }
}