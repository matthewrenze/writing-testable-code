using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableCodeDemos.Module4.Shared;

namespace TestableCodeDemos.Module4.Easy
{
    [TestFixture]
    public class PrintInvoiceCommandTests
    {
        private PrintInvoiceCommand _command;
        private AutoMoqer _mocker;
        private Invoice _invoice;

        private const int InvoiceId = 1;
        private const string UserName = "mrenze";

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IDatabase>()
                .Setup(p => p.GetInvoice(InvoiceId))
                .Returns(_invoice);

            _mocker.GetMock<IIdentityService>()
                .Setup(p => p.GetUserName())
                .Returns(UserName);

            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        public void TestExecuteShouldPrintInvoice()
        {
            _command.Execute(InvoiceId);

            _mocker.GetMock<IInvoiceWriter>()
                .Verify(p => p.Write(_invoice),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldLastPrintedByToCurrentUserName()
        {
            _command.Execute(InvoiceId);

            Assert.That(_invoice.LastPrintedBy,
                Is.EqualTo(UserName));
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(InvoiceId);

            _mocker.GetMock<IDatabase>()
                .Verify(p => p.Save(),
                    Times.Once);
        }
    }
}
