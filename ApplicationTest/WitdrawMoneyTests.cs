using Application.Features;
using ApplicationTest.TestData;
using System;

namespace ApplicationTest
{
    public class WitdrawMoneyTests
    {
        private readonly WithdrawMoney witdrawMoney = new WithdrawMoney(new TestAccountRepository(), new TestNotificationService());

        [Test]
        public void IfAccounWasNotFoundTest()
        {
            Assert.Throws<ArgumentException>(() => witdrawMoney.Execute(Constants.NullAccount, 400));   
        }

        [Test]
        public void IfAmountLessThanZeroTest()
        {
            Assert.Throws<ArgumentException>(() => witdrawMoney.Execute(Constants.NullAccount, -100));
        }

        [Test]
        public void InsufficientFundsTest()
        {
            Assert.Throws<InvalidOperationException>(() => witdrawMoney.Execute(Constants.AccountWithoutBalanceMoney, 600));
        }

        [Test]
        public void NotifyFundsLowTest()
        {
            Assert.Throws<NotImplementedException>(() => witdrawMoney.Execute(Constants.AccountWithLowBalanceMoney, 400));
        }

        [Test]
        public void AccountWithHugeAmountMoneyTest()
        {
            Assert.IsInstanceOf<System.Action>(() => witdrawMoney.Execute(Constants.AccountWithLowBalanceMoney, 400));
        }
    }
}