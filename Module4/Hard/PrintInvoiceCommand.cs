using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module4.Shared;

namespace TestableCodeDemos.Module4.Hard
{
    public class PrintInvoiceCommand
    {
        private readonly Container _container;

        public PrintInvoiceCommand(
            Container container)
        {
            _container = container;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _container
                .Get<IDatabase>()
                .GetInvoice(invoiceId);

            _container.Get<IInvoiceWriter>()
                .Write(invoice);

            invoice.LastPrintedBy = _container
                .Get<ISession>()
                .GetLogin()
                .GetUser()
                .GetUserName();

            _container
                .Get<IDatabase>()
                .Save();
        }
    }
}