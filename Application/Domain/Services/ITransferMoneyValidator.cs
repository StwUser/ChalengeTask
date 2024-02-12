using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Services
{
    public interface ITransferMoneyValidator
    {
        void ValidateAccountFrom(Account from, decimal amount);
        void ValidateAccountTo(Account to, decimal amount);
    }
}
