using Solid.DeveloperTest.PayementInterfaces;
using Solid.DeveloperTest.Services;
using Solid.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.DeveloperTest.PaymentTypes
{
    public class ChapsPayment : IChapsPayment
    {
        public bool isAllowedPayementScheme( Account account)
        {
            return account != null && account.Status == AccountStatus.Live
                ? account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps)
                : false;
        }
    }
}