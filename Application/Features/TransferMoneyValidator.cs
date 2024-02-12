using Application.Domain;
using Application.Domain.Services;
using System;

namespace Application.Features
{
    public class TransferMoneyValidator : ITransferMoneyValidator
    {
        private readonly INotificationService notificationService;
        public TransferMoneyValidator(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        public void ValidateAccountFrom(Account from, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount can't be less than 0.");
            }

            if (from.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }

            if (from.Balance - amount < Account.LowerBalanceLimit)
            {
                this.notificationService.NotifyFundsLow(from.User.Email);
            }
        }

        public void ValidateAccountTo(Account to, decimal amount)
        {
            var paidIn = to.PaidIn + amount;

            if (paidIn > Account.PayInLimit)
            {
                throw new InvalidOperationException("Account pay in limit reached");
            }

            if (Account.PayInLimit - paidIn < 500m)
            {
                this.notificationService.NotifyApproachingPayInLimit(to.User.Email);
            }
        }
    }
}
