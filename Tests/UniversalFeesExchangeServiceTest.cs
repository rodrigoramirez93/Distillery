using BusinessLogic.Implementations;
using System;
using Xunit;

namespace Tests
{
    public class UniversalFeesExchangeServiceTest
    {
        [Fact]
        public void CheckSingleInstance()
        {
            UniversalFeesExchangeService.CalculateFee(DateTime.Now);
            var isntanceA = UniversalFeesExchangeService.GetInstance();
            var isntanceB = UniversalFeesExchangeService.GetInstance();
            var isntanceC = UniversalFeesExchangeService.GetInstance();

            Assert.Equal(isntanceA, isntanceB);
            Assert.Equal(isntanceB, isntanceC);
            Assert.Equal(isntanceA, isntanceC);

            UniversalFeesExchangeService.CalculateFee(DateTime.Now.AddHours(1));
            var isntanceD = UniversalFeesExchangeService.GetInstance();
            var isntanceE = UniversalFeesExchangeService.GetInstance();
            var isntanceF = UniversalFeesExchangeService.GetInstance();

            Assert.Equal(isntanceD, isntanceE);
            Assert.Equal(isntanceE, isntanceF);
            Assert.Equal(isntanceD, isntanceF);
            Assert.NotEqual(isntanceA, isntanceD);
            Assert.NotEqual(isntanceB, isntanceE);
            Assert.NotEqual(isntanceC, isntanceF);
        }

        [Fact]
        public void CheckFeeCalculations()
        {
            var resultA = UniversalFeesExchangeService.CalculateFee(DateTime.Now);
            var resultB = UniversalFeesExchangeService.CalculateFee(DateTime.Now);

            Assert.Equal(resultA, resultB);

            var resultC = UniversalFeesExchangeService.CalculateFee(DateTime.Now.AddHours(1));
            var resultD = UniversalFeesExchangeService.CalculateFee(DateTime.Now.AddHours(1));

            Assert.Equal(resultC, resultD);

            var resultE = UniversalFeesExchangeService.CalculateFee(DateTime.Now.AddHours(2));
            var resultF = UniversalFeesExchangeService.CalculateFee(DateTime.Now.AddHours(3));

            Assert.NotEqual(resultA, resultC);
            Assert.NotEqual(resultE, resultF);
            Assert.NotEqual(resultD, resultF);
        }
    }
}