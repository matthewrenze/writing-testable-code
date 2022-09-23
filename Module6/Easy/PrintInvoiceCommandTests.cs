using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using TestableCodeDemos.Module6.Shared;

namespace TestableCodeDemos.Module6.Easy
{
    [TestFixture]
    public class PrintInvoiceCommandTests
    {
        private PrintInvoiceCommand _command;
        private AutoMocker _mocker;
        private Invoice _invoice;

        private const int InvoiceId = 1;
        private const string UserName = "mrenze";

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice();

            _mocker = new AutoMocker();

            _mocker.GetMock<IDatabase>().
                Setup(p => p.GetInvoice(InvoiceId))
                .Returns(_invoice);

            _mocker.GetMock<ISecurity>()
                .Setup(p => p.IsAdmin())
                .Returns(true);

            _mocker.GetMock<ISecurity>()
                .Setup(p => p.GetUserName())
                .Returns(UserName);

            _command = _mocker.CreateInstance<PrintInvoiceCommand>();
        }

        [Test]
        public void TestExecuteShouldThrowExceptionIfUserIsNotAdmin()
        {
            _mocker.GetMock<ISecurity>()
                .Setup(p => p.IsAdmin())
                .Returns(false);

            Assert.That(() => _command.Execute(InvoiceId), 
                Throws.TypeOf<UserNotAuthorizedException>());
        }

        [Test]
        public void TestExecuteShouldPrintInvoice()
        {
            _command.Execute(InvoiceId);

            _mocker.GetMock<IInvoiceWriter>()
                .Verify(p => p.Print(_invoice),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSetLastPrintedByToCurrentUser()
        {
            _command.Execute(InvoiceId);

            Assert.That(_invoice.LastPrintedBy,
                Is.EqualTo("mrenze"));
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
