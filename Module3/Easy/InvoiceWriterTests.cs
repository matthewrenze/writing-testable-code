using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using TestableCodeDemos.Module3.Shared;

namespace TestableCodeDemos.Module3.Easy
{
    [TestFixture]
    public class InvoiceWriterTests
    {
        private InvoiceWriter _writer;
        private AutoMocker _mocker;
        private Invoice _invoice;

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice()
            {
                Id = 1,
                IsOverdue = false
            };

            _mocker = new AutoMocker();

            _writer = _mocker.CreateInstance<InvoiceWriter>();
        }

        [Test]
        public void TestWriteShouldSetPageLayout()
        {
            _writer.Write(_invoice);

            var layout = _mocker
                .GetMock<IPageLayout>().Object;

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetPageLayout(layout),
                    Times.Once);
        }

        [Test]
        public void TestWriteShouldPrintOverdueInvoiceInRed()
        {
            _invoice.IsOverdue = true;

            _writer.Write(_invoice);

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetInkColor("Red"),
                    Times.Once);
        }

        [Test]
        public void TestWriteShouldPrintOnTimeInvoiceInDefaultColor()
        {
            _writer.Write(_invoice);

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetInkColor(It.IsAny<string>()),
                    Times.Never);
        }

        [Test]
        [TestCase("Invoice ID: 1")]
        // Remaining test cases would go here
        public void TestWriteShouldPrintInvoiceNumber(string line)
        {
            _writer.Write(_invoice);

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.WriteLine(line), 
                    Times.Once());
        }        
    }
}
