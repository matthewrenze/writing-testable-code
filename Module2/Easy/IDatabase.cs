using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module2.Shared;

namespace TestableCodeDemos.Module2.Easy
{
    public interface IDatabase
    {
        Invoice GetInvoice(int invoiceId);
    }
}