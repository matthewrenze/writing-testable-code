using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module6.Shared
{
    public class InvoiceWriter : IInvoiceWriter
    {
        public void Print(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
