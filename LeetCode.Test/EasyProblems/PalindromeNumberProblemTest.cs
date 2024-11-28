using LeetCode.Problems.EasyProblems;

namespace LeetCode.Test.EasyProblems
{
    public class PalindromeNumberProblemTest
    {
        private PalindromeNumberProblem _problem;

        [SetUp]
        public void Setup()
        {
            _problem = new PalindromeNumberProblem();
        }

        [Test]
        public void Case1()
        {
            Assert.IsTrue(_problem.IsPalindrome(121));
        }

        [Test]
        public void Case2()
        {
            Assert.IsFalse(_problem.IsPalindrome(-121));
        }

        [Test]
        public void Case3()
        {
            Assert.IsFalse(_problem.IsPalindrome(10));
        }
    }
}
