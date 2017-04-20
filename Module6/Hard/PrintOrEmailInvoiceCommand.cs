using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module6.Shared;

namespace TestableCodeDemos.Module6.Hard
{
    public class PrintOrEmailInvoiceCommand
    {
        private readonly IDatabase _database;
        private readonly ISecurity _security;
        private readonly IInvoiceEmailer _emailer;
        private readonly IInvoiceWriter _writer;

        public PrintOrEmailInvoiceCommand(
            IDatabase database,
            ISecurity security,
            IInvoiceEmailer emailer,
            IInvoiceWriter writer)
        {
            _database = database;
            _security = security;
            _emailer = emailer;
            _writer = writer;
        }

        public void Execute(int invoiceId, bool shouldEmail)
        {
            var invoice = _database.GetInvoice(invoiceId);

            if (shouldEmail)
            {
                if (invoice.EmailAddress == string.Empty)
                    throw new EmailAddressIsBlankException();

                _emailer.Email(invoice);
            }
            else
            {
                if (!_security.IsAdmin())
                    throw new UserNotAuthorizedException();

                _writer.Print(invoice);

                invoice.LastPrintedBy = _security.GetUserName();

                _database.Save();
            }            
        }
    }
}
