using Solid.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.DeveloperTest.PaymentTypes
{
    public class FastPayment 
    {
        public bool isAllowedPayementScheme( Account account, decimal amount)
        {
            return account != null && CheckBalance(account,amount)
                ? account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments)
                : false;

        }
        public bool CheckBalance(Account account, decimal requestAmount)
        {
            return account.Balance < requestAmount ? false : true;
        }
    }
}
