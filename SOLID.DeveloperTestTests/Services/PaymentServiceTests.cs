//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solid.DeveloperTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Solid.DeveloperTest.PaymentTypes;

using NUnit.Framework;
using Solid.DeveloperTest.PayementInterfaces;

namespace Solid.DeveloperTest.Services.Tests
{

    [TestFixture]
    public class PaymentServiceTests
    {

        private Types.MakePaymentRequest _makePaymentRequest;
        private Types.Account _account;
        private iBacsPayment  _backsPayment;
        private iFastPayment  _fastPayment;
        private IChapsPayment _chapsPayment;
        private IPaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PaymentTypes.BacsPayment>().As<iBacsPayment>();
            builder.RegisterType< PaymentTypes.FastPayment> ().As<iFastPayment>();
            builder.RegisterType<PaymentTypes.ChapsPayment>().As<IChapsPayment>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            var container = builder.Build();

            _backsPayment = container.Resolve<iBacsPayment>();
            _fastPayment = container.Resolve<iFastPayment>();
            _chapsPayment = container.Resolve<IChapsPayment>();
            _paymentService = container.Resolve<IPaymentService>();
        }

        [Test]
        public void Payement_Should_be_Approved_For_Backs_When_states_Is_Live()
        {
           

            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Bacs, Status = Types.AccountStatus.Live };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Bacs };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(true, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_be_Approved_For_Backs_When_states_Is_InboundPaymentsOnly()
        {
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Bacs, Status = Types.AccountStatus.InboundPaymentsOnly };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Bacs };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(true, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_be_Approved_For_Backs_When_states_Is_Disabled()
        {
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Bacs, Status = Types.AccountStatus.Disabled };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Bacs };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(true, _makePaymentResult.Success);

        }


        [Test]
        public void Payement_Should_Not_be_Approved_For_Backs_When_Account_Is_Null()
        {
            
            _account = null;
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Bacs };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(false, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_be_Approved_For_Chaps_When_states_Is_Live()
        {
           
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Chaps, Status= Types.AccountStatus.Live  };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Chaps };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(true, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_Not_be_Approved_For_Chaps_When_states_Is_InboundPaymentsOnly()
        {
           
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Chaps, Status = Types.AccountStatus.InboundPaymentsOnly };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Chaps };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(false, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_Not_be_Approved_For_Chaps_When_states_Is_Disabled()
        {
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.Chaps, Status = Types.AccountStatus.Disabled };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.Chaps };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(false, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_Not_be_Approved_For_Faster_Payment_When_Amount_Is_Greater_Than_Balance()
        {
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.FasterPayments, Status = Types.AccountStatus.Disabled };
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.FasterPayments };
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(false, _makePaymentResult.Success);

        }

        [Test]
        public void Payement_Should_Not_be_Approved_For_Faster_Payment_When_Amount_Is_Less_Than_Balance()
        {
            _account = new Types.Account { AccountNumber = "1223456", AllowedPaymentSchemes = Types.AllowedPaymentSchemes.FasterPayments, Status = Types.AccountStatus.Disabled , Balance= 100M};
            _makePaymentRequest = new Types.MakePaymentRequest { Amount = 25M, CreditorAccountNumber = "123456", DebtorAccountNumber = "56789", PaymentDate = DateTime.Now, PaymentScheme = Types.PaymentScheme.FasterPayments};
            Types.MakePaymentResult _makePaymentResult = new Types.MakePaymentResult
            {
                Success = true
            };
            _paymentService.CheckPaymentScheme(_makePaymentRequest, _account, _makePaymentResult);
            Assert.AreEqual(true, _makePaymentResult.Success);

        }
    }
}