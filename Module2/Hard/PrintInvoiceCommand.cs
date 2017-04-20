using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module2.Shared;

namespace TestableCodeDemos.Module2.Hard
{
    public class PrintInvoiceCommand
    {
        public void Execute(int invoiceId)
        {
            var database = new Database();

            var invoice = database.GetInvoice(invoiceId);

            Printer.WriteLine("Invoice ID: " + invoice.Id);

            Printer.WriteLine("Total: $" + invoice.Total);

            var dateTime = DateTime.Now;

            Printer.WriteLine("Printed: " + dateTime.ToShortDateString());
        }
    }
}
