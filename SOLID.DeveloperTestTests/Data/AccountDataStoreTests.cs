using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solid.DeveloperTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.DeveloperTest.PaymentTypes;

namespace Solid.DeveloperTest.Data.Tests
{
    [TestClass()]
    public class AccountDataStoreTests
    {
     

        [TestMethod()]
        public void Given_Valid_Account_Deatils_Allowed_PaymentScheme_Should_be_BacsPayment()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            var result = accountDataStore.GetAccount("12345678");
            Assert.AreEqual(DeveloperTest.Types.AllowedPaymentSchemes.Bacs, result.AllowedPaymentSchemes);
        }

        [TestMethod()]
        public void Given_Valid_Account_Deatils_Allowed_PaymentScheme_Should_be_ChapsPayment()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            var result = accountDataStore.GetAccount("78917898");
            Assert.AreEqual(DeveloperTest.Types.AllowedPaymentSchemes.Chaps, result.AllowedPaymentSchemes);
        }


        [TestMethod()]
        public void Given_Valid_Account_Deatils_Allowed_PaymentScheme_Should_be_FastPayment()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            var result = accountDataStore.GetAccount("15161718");
            Assert.AreEqual(DeveloperTest.Types.AllowedPaymentSchemes.FasterPayments, result.AllowedPaymentSchemes);
        }

        [TestMethod()]
        public void Given_Valid_Account_Deatils_With_Lower_Balance_Should_not_Get_Payment()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            var result = accountDataStore.GetAccount("15161718");
            FastPayment fastPayment = new FastPayment();

            Assert.AreEqual(false, fastPayment.CheckBalance(result,450M));
        }

        [TestMethod()]
        public void Given_Valid_Account_Deatils_With_Higher_Balance_Should_Get_Payment()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            var result = accountDataStore.GetAccount("19202122");
            FastPayment fastPayment = new FastPayment();

            Assert.AreEqual(true, fastPayment.CheckBalance(result, 450M));
        }
    }
}