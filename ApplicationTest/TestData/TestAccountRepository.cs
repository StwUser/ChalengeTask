using Application.DataAccess;
using Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.TestData
{
    public class TestAccountRepository : IAccountRepository
    {
        public Account GetAccountById(Guid accountId)
        {
            if (accountId == Constants.NullAccount)
            {
                return null;
            }
            if (accountId == Constants.AccountWithoutBalanceMoney)
            {
                return new Account { Id = accountId, Balance = 100, User = new User { Email = "Test@gmail.com", Name = "User1" } };
            }
            else if (accountId == Constants.AccountWithLowBalanceMoney)
            {
                return new Account { Id = accountId, Balance = 500, User = new User { Email = "Test2@gmail.com", Name = "User2" } };
            }
            else if (accountId == Constants.AccountWithHugeBalanceMoney)
            {
                return new Account { Id = accountId, Balance = 50000, User = new User { Email = "Test2@gmail.com", Name = "User2" } };
            }

            return null;
        }

        public void Update(Account account)
        {
            Console.WriteLine("Account was updated.");
        }
    }
}
