using Solid.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Solid.DeveloperTest.Data
{
    public class AccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 

            Account query = (from account in accounts
                             where account.AccountNumber == accountNumber
                             select new Account
                             {
                                 AccountNumber = account.AccountNumber,
                                 AllowedPaymentSchemes = account.AllowedPaymentSchemes,
                                 Balance = account.Balance,
                                 Status = account.Status,
                             }).FirstOrDefault();


            return query;
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }

        protected static List<Account> accounts = new List<Account>
    {
        new Account { AccountNumber = "12345678", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Bacs, Balance = 25M, Status = AccountStatus.Live },
        new Account { AccountNumber = "34567891", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Bacs , Balance = 35M, Status = AccountStatus.Disabled},


        new Account { AccountNumber = "78917898", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Chaps ,  Balance = 45M, Status = AccountStatus.InboundPaymentsOnly },
        new Account { AccountNumber = "12131415", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Chaps, Balance = 55M, Status = AccountStatus.Live },


        new Account { AccountNumber = "15161718", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.FasterPayments , Balance = 65M, Status = AccountStatus.Live},
        new Account { AccountNumber = "19202122", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.FasterPayments, Balance = 700M, Status = AccountStatus.Disabled },

    };
    }
}
