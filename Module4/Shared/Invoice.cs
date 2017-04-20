using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module4.Shared
{
    public class Invoice
    {
        // Remaining invoice fields would go here

        public InvoiceStatus Status { get; set; }

        public string LastPrintedBy { get; set; }
    }
}
