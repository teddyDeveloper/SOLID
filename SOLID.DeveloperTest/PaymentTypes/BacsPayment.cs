using Solid.DeveloperTest.PayementInterfaces;
using Solid.DeveloperTest.Services;
using Solid.DeveloperTest.Types;

namespace Solid.DeveloperTest.PaymentTypes
{
    public class BacsPayment : iBacsPayment
    {
        public bool isAllowedPayementScheme(Account account)
        {
            return account != null ? account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs) : false;

        }
    }
}
