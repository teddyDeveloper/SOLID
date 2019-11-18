using Solid.DeveloperTest.Data;
using Solid.DeveloperTest.PayementInterfaces;
using Solid.DeveloperTest.PaymentTypes;
using Solid.DeveloperTest.Types;
using System.Configuration;

namespace Solid.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private iBacsPayment  _backs;
        private IChapsPayment _chaps;
        private iFastPayment _fasterPayment;

        public PaymentService(iBacsPayment iBacsPayment, iFastPayment iFastPayment , IChapsPayment iChapsPayment)
        {
            _backs = iBacsPayment;
            _fasterPayment = iFastPayment;
            _chaps = iChapsPayment;

        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            Account account = null;

            if (dataStoreType == "Backup")
            {
                var accountDataStore = new BackupAccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            }
            else
            {
                var accountDataStore = new AccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            }

            var result = new MakePaymentResult();

            CheckPaymentScheme(request, account, result);

            ProcessPayment(request, dataStoreType, account, result);

            return result;
        }

        public  void ProcessPayment(MakePaymentRequest request, string dataStoreType, Account account, MakePaymentResult result)
        {
            if (result.Success)
            {
                account.Balance -= request.Amount;

                if (dataStoreType == "Backup")
                {
                    var accountDataStore = new BackupAccountDataStore();
                    accountDataStore.UpdateAccount(account);
                }
                else
                {
                    var accountDataStore = new AccountDataStore();
                    accountDataStore.UpdateAccount(account);
                }
            }
        }

        public void CheckPaymentScheme(MakePaymentRequest request, Account account, MakePaymentResult result)
        {

          
           
            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:

                    result.Success = _backs.isAllowedPayementScheme(account);
                    break;

                case PaymentScheme.FasterPayments:

                    result.Success = _fasterPayment.isAllowedPayementScheme(account, request.Amount);
                    break;

                case PaymentScheme.Chaps:
                    result.Success = _chaps.isAllowedPayementScheme(account);
                    break;
            }
        }
    }
}
