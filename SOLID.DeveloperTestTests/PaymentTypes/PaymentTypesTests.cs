using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solid.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.DeveloperTest.PaymentTypes;

namespace Solid.DeveloperTestTests.PaymentTypes.Test
{
    [TestClass()]
    public class PaymentTypesTests
    {

        private BacsPayment _backs;
        private ChapsPayment _chaps;
        private FastPayment _fastPayment;
        private Account _account;

        [TestMethod()]
        public void Given_Valid_Account_Deatils_BacsPayment_Should_Process()
        {
            _backs = new BacsPayment();
            _account = new Account { AccountNumber = "1223456", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Bacs };
            Assert.AreEqual(true, _backs.isAllowedPayementScheme( _account));
        }
        [TestMethod()]
        public void Given_Valid_Account_Deatils_ChapsPayment_Should_Process()
        {
            _chaps = new ChapsPayment();
            _account = new DeveloperTest.Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.Chaps, Balance = 80M };
            Assert.AreEqual(true, _chaps.isAllowedPayementScheme( _account));
        }

        [TestMethod()]
        public void Given_Valid_Account_Deatils_FastPayment_Should_Process()
        {
            _fastPayment = new FastPayment();
            _account = new DeveloperTest.Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = DeveloperTest.Types.AllowedPaymentSchemes.FasterPayments, Balance=  890M};
            Assert.AreEqual(true, _fastPayment.isAllowedPayementScheme( _account,23M));
        }
    }
}
