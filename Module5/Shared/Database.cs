using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module5.Shared
{
    public class Database : IDatabase
    {
        public Invoice GetInvoice(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
