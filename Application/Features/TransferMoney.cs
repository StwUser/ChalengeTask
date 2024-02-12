using Application.Domain;
using Application.DataAccess;
using Application.Domain.Services;
using System;

namespace Application.Features
{
    public class TransferMoney
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITransferMoneyValidator validator;

        public TransferMoney(IAccountRepository accountRepository, ITransferMoneyValidator validator)
        {
            this.accountRepository = accountRepository;
            this.validator = validator;
        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var from = this.accountRepository.GetAccountById(fromAccountId) ?? throw new ArgumentException("Account not found.");
            var to = this.accountRepository.GetAccountById(toAccountId) ?? throw new ArgumentException("Account not found.");

            validator.ValidateAccountFrom(from, amount);
            validator.ValidateAccountTo(to, amount);

            from.Balance -= amount;
            from.Withdrawn -= amount;

            to.Balance += amount;
            to.PaidIn += amount;

            this.accountRepository.Update(from);
            this.accountRepository.Update(to);
        }
    }
}
