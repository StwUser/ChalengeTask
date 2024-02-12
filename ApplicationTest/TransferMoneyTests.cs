using Application.Domain.Services;
using Application.Features;
using ApplicationTest.TestData;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTest
{
    public class TransferMoneyTests
    {
        private readonly TransferMoney transferMoney = new TransferMoney(new TestAccountRepository(), new TransferMoneyValidator(new TestNotificationService()));

        [Test]
        public void IfAccounFromWasNotFoundTest()
        {
            Assert.Throws<ArgumentException>(() => transferMoney.Execute(Constants.NullAccount, Constants.AccountWithHugeBalanceMoney, 400));   
        }

        [Test]
        public void IfAmountLessThanZeroTest()
        {
            Assert.Throws<ArgumentException>(() => transferMoney.Execute(Constants.NullAccount, Constants.AccountWithHugeBalanceMoney, -100));
        }

        [Test]
        public void InsufficientFundsTest()
        {
            Assert.Throws<InvalidOperationException>(() => transferMoney.Execute(Constants.AccountWithoutBalanceMoney, Constants.AccountWithHugeBalanceMoney, 600));
        }

        [Test]
        public void NotifyFundsLowTest()
        {
            Assert.Throws<NotImplementedException>(() => transferMoney.Execute(Constants.AccountWithLowBalanceMoney, Constants.AccountWithHugeBalanceMoney, 400));
        }

        [Test]
        public void AccountWithHugeAmountMoneyTest()
        {
            Assert.IsInstanceOf<System.Action>(() => transferMoney.Execute(Constants.AccountWithLowBalanceMoney, Constants.AccountWithHugeBalanceMoney, 400));
        }

        [Test]
        public void AccountPayLimitReachedTest()
        {
            Assert.Throws<InvalidOperationException>(() => transferMoney.Execute(Constants.AccountWithHugeBalanceMoney, Constants.AccountWithHugeBalanceMoney, 1400));
        }

        [Test]
        public void NotifyApproachingPayInLimitTest()
        {
            Assert.Throws<NotImplementedException>(() => transferMoney.Execute(Constants.AccountWithHugeBalanceMoney, Constants.AccountWithHugeBalanceMoney, 600));
        }
    }
}