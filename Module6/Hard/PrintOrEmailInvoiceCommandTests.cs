using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using TestableCodeDemos.Module6.Shared;

namespace TestableCodeDemos.Module6.Hard
{
    [TestFixture]
    public class PrintOrEmailInvoiceCommandTests
    {
        private PrintOrEmailInvoiceCommand _command;
        private AutoMocker _mocker;
        private Invoice _invoice;

        private const int InvoiceId = 1;
        private const string EmailAddress = "email@test.com";
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

            _command = _mocker.CreateInstance<PrintOrEmailInvoiceCommand>();
        }

        [Test]
        public void TestExecuteForEmailingInvoiceWithNoEmailAddressShouldThrowException()
        {
            _invoice.EmailAddress = string.Empty;

            Assert.That(() => _command.Execute(InvoiceId, true),
                Throws.TypeOf<EmailAddressIsBlankException>());
        }

        [Test]
        public void TestExecuteShouldEmailInvoiceIfEmailing()
        {
            _invoice.EmailAddress = EmailAddress;

            _command.Execute(InvoiceId, true);

            _mocker.GetMock<IInvoiceEmailer>()
                .Verify(p => p.Email(_invoice),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldThrowExceptionIfPrintingAndUserIsNotAdmin()
        {
            _mocker.GetMock<ISecurity>()
                .Setup(p => p.IsAdmin())
                .Returns(false);

            Assert.That(() => _command.Execute(InvoiceId, false),
                Throws.TypeOf<UserNotAuthorizedException>());
        }

        [Test]
        public void TestExecuteShouldPrintInvoiceIfPrinting()
        {
            _command.Execute(InvoiceId, false);

            _mocker.GetMock<IInvoiceWriter>()
                .Verify(p => p.Print(_invoice),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSetLastPrintedByToCurrentUserIfPrinting()
        {
            _command.Execute(InvoiceId, false);

            Assert.That(_invoice.LastPrintedBy,
                Is.EqualTo("mrenze"));
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabaseIfPrinting()
        {
            _command.Execute(InvoiceId, false);

            _mocker.GetMock<IDatabase>()
                .Verify(p => p.Save(),
                    Times.Once);
        }
    }
}
