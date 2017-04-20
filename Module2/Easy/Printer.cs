using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module2.Easy
{
    public class Printer : IPrinter
    {
        public void WriteLine(string text)
        {
            throw new NotImplementedException();
        }
    }
}
