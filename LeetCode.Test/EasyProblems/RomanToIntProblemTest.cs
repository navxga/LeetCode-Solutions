using LeetCode.Problems.EasyProblems;

namespace LeetCode.Test.EasyProblems
{
    public class RomanToIntProblemTest
    {
        private RomanToIntProblem _problem;

        [SetUp]
        public void Setup()
        {
            _problem = new RomanToIntProblem();
        }

        [Test]
        public void Case1()
        {
            _problem.RomanToInt("LVIII");
        }

        [Test]
        public void Case2()
        {
        }

        [Test]
        public void Case3()
        {
        }
    }
}
