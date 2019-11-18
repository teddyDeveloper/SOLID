using Solid.DeveloperTest.Types;

namespace Solid.DeveloperTest.Services
{
    public interface IPaymentService
    {
        void CheckPaymentScheme(MakePaymentRequest request, Account account, MakePaymentResult result);
        MakePaymentResult MakePayment(MakePaymentRequest request);
        void ProcessPayment(MakePaymentRequest request, string dataStoreType, Account account, MakePaymentResult result);
    }
}