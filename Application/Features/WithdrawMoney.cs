using Application.DataAccess;
using Application.Domain;
using Application.Domain.Services;
using System;

namespace Application.Features
{
    public class WithdrawMoney
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITransferMoneyValidator validator;

        public WithdrawMoney(IAccountRepository accountRepository, ITransferMoneyValidator validator)
        {
            this.accountRepository = accountRepository;
            this.validator = validator;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            var from = this.accountRepository.GetAccountById(fromAccountId) ?? throw new ArgumentException("Account not found.");
            validator.ValidateAccountFrom(from, amount);

            from.Balance -= amount;
            from.Withdrawn -= amount;
            this.accountRepository.Update(from);
        }
    }
}
