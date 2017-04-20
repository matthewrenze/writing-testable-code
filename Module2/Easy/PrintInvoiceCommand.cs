using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module2.Easy
{
    public class PrintInvoiceCommand
    {
        private readonly IDatabase _database;
        private readonly IPrinter _printer;
        private readonly IDateTimeWrapper _dateTime;

        public PrintInvoiceCommand(
            IDatabase database,
            IPrinter printer,
            IDateTimeWrapper dateTime)
        {
            _database = database;
            _printer = printer;
            _dateTime = dateTime;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            _printer.WriteLine("Invoice ID: " + invoice.Id);

            _printer.WriteLine("Total: $" + invoice.Total);

            var dateTime = _dateTime.GetNow();

            _printer.WriteLine("Printed: " + dateTime.ToShortDateString());
        }
    }
}
