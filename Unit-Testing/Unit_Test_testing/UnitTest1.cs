using System;
using Xunit;
using Unit_Testing;

namespace Unit_Test_testing
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3000, 8000)]
        [InlineData(0.50, 5000.50)]
        public void TestDeposit(decimal value, decimal expectedResult)
        {
            Assert.Equal(expectedResult, Program.CalculateBalanceDeposit(value));
        }

        [Theory]
        [InlineData(3000, 2000)]
        [InlineData(0.50, 4999.50)]
        public void TestWithdraw(decimal value, decimal expectedResult)
        {
            Assert.Equal(expectedResult, Program.CalculateBalanceWithdraw(value));
        }

        [Theory]
        [InlineData(4, false)]
        [InlineData(12, false)]
        public void TestStartApp(int value, bool expectedResult)
        {
            Assert.Equal(expectedResult, Program.startApp(value));
        }
    }
}
