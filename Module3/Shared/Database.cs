using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module3.Shared
{
    public class Database : IDatabase
    {
        public Invoice GetInvoice(int invoiceId)
        {
            throw new System.NotImplementedException();
        }
    }
}