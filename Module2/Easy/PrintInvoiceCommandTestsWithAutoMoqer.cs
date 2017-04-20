using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableCodeDemos.Module2.Shared;

namespace TestableCodeDemos.Module2.Easy
{
    [TestFixture]
    public class PrintInvoiceCommandTestsWithAutoMoqer
    {
        private PrintInvoiceCommand _command;
        private AutoMoqer _mocker;
        private Invoice _invoice;

        private const int InvoiceId = 1;
        private const decimal Total = 4.50m;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice()
            {
                Id = InvoiceId,
                Total = Total
            };

            _mocker = new AutoMoqer();

            _mocker.GetMock<IDatabase>()
                .Setup(p => p.GetInvoice(InvoiceId))
                .Returns(_invoice);

            _mocker.GetMock<IDateTimeWrapper>()
                .Setup(p => p.GetNow())
                .Returns(Date);

            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        [TestCase("Invoice ID: 1")]
        [TestCase("Total: $4.50")]
        [TestCase("Printed: 2/3/2001")]
        public void TestExecuteShouldPrintLine(string line)
        {
            _command.Execute(InvoiceId);

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.WriteLine(line),
                    Times.Once);
        }
    }
}
