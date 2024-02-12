using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.TestData
{
    public static class Constants
    {
        public static Guid NullAccount = new Guid("d9711a33-2bd0-41f5-ac34-5b32f3a12cd7");
        public static Guid AccountWithoutBalanceMoney = new Guid("7e243658-cb7f-4a5e-af92-c2c0f1b857ca");
        public static Guid AccountWithLowBalanceMoney = new Guid("afa093b1-3885-4f7c-a04f-71e5eda8ed22");
        public static Guid AccountWithHugeBalanceMoney = new Guid("ce0c5a44-cf04-45af-bd6a-38bea602de17");
    }
}
