using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module5.Shared;

namespace TestableCodeDemos.Module5.Hard
{
    public class PrintInvoiceCommand
    {
        private readonly IDatabase _database;
        private readonly IInvoiceWriter _writer;

        public PrintInvoiceCommand(
            IDatabase database,
            IInvoiceWriter writer)
        {
            _database = database;
            _writer = writer;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            var security = Security.GetInstance();

            if (!security.IsAdmin())
                throw new UserNotAuthorizedException();
            
            _writer.Print(invoice);

            invoice.LastPrintedBy = security.GetUserName();

            _database.Save();
        }
    }
}
