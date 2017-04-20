using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module5.Shared
{
    public interface IInvoiceWriter
    {
        void Print(Invoice invoice);
    }
}