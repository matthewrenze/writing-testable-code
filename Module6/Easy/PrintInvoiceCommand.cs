using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module6.Shared;

namespace TestableCodeDemos.Module6.Easy
{
    public class PrintInvoiceCommand
    {
        private readonly IDatabase _database;
        private readonly ISecurity _security;
        private readonly IInvoiceWriter _processor;

        public PrintInvoiceCommand(
            IDatabase database,
            ISecurity security,
            IInvoiceWriter processor)
        {
            _database = database;
            _security = security;
            _processor = processor;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            if (!_security.IsAdmin())
                throw new UserNotAuthorizedException();

            _processor.Print(invoice);

            invoice.LastPrintedBy = _security.GetUserName();

            _database.Save();
        }
    }
}
