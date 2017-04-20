using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module6.Shared
{
    public interface IDatabase
    {
        Invoice GetInvoice(int invoiceId);

        void Save();
    }
}
