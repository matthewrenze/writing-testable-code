using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Module6.Shared
{
    public interface IEmailValidator
    {
        bool IsValid(string address);
    }
}
