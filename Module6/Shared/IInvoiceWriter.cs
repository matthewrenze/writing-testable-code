using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module6.Shared
{
    public interface IInvoiceWriter
    {
        void Print(Invoice invoice);
    }
}