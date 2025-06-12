using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatika.PatternStrategyHomeWork
{
    internal class TestForStrategy
    {
        private Program _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Program();
        }

        [DataTestMethod]
        [DataRow("1 + 2", 3]
        [DataRow("3 / 2", 1.5]
        [DataRow("3 - 3", 0]
        [DataRow("2 + 2", 4]
        [DataRow("5 + 5", 10]
        [DataRow("3 / 0", double.PositiveInfinity,]
        [DataRow("-3 / 0", double.NegativeInfinity]
        [DataRow("-3 - 1", -4]
        [DataRow("100 * 2", 200]
        public void TestBasicOperations(string input, double expected)
        {
            var result = _calculator.Calculator(input);
            Assert.AreEqual(expected, result, delta: 0.001,
                message: $"Failed for input: '{input}'");
        }
    }
}
