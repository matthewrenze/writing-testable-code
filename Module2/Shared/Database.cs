using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module2.Easy;

namespace TestableCodeDemos.Module2.Shared
{
    public class Database : IDatabase
    {
        public Invoice GetInvoice(int invoiceId)
        {
            throw new System.NotImplementedException();
        }
    }
}