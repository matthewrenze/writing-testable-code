using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module3.Shared
{
    public interface IDatabase
    {
        Invoice GetInvoice(int invoiceId);
    }
}