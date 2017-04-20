using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module5.Shared
{
    public interface IDatabase
    {
        Invoice GetInvoice(int invoiceId);

        void Save();
    }
}
