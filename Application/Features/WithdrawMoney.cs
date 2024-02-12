using Application.DataAccess;
using Application.Domain;
using Application.Domain.Services;
using System;

namespace Application.Features
{
    public class WithdrawMoney
    {
        private readonly IAccountRepository accountRepository;
        private readonly INotificationService notificationService;

        public WithdrawMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            var from = this.accountRepository.GetAccountById(fromAccountId) ?? throw new ArgumentException("Account not found.");
            
            if (ValidateAccount(from, amount))
            {
                from.Balance -= amount;
                this.accountRepository.Update(from);
            }
        }

        private bool ValidateAccount(Account from, decimal amount) 
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

            return true;
        }
    }
}
