using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Module4.Shared
{
    public interface IInvoiceWriter
    {
        void Write(Invoice invoice);
    }
}
