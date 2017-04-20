using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableCodeDemos.Module3.Shared;

namespace TestableCodeDemos.Module3.Hard
{
    public class InvoiceWriter
    {
        private readonly IPrinter _printer;
        private readonly Invoice _invoice;

        public InvoiceWriter(
            IPrinter printer, 
            Invoice invoice)
        {
            _printer = printer;
            _invoice = invoice;

            _printer.SetPageLayout(new PageLayout());

            if (_invoice.IsOverdue)
                _printer.SetInkColor("Red");
        }

        public void Write()
        {
            _printer.WriteLine("Invoice ID: " + _invoice.Id);

            // Remaining print statements would go here
        }
    }
}
