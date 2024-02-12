using Application.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.TestData
{
    public class TestNotificationService : INotificationService
    {
        public void NotifyApproachingPayInLimit(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void NotifyFundsLow(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
