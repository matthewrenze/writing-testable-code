using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module3.Shared
{
    public class Printer :IPrinter
    {
        public void SetInkColor(string red)
        {
            throw new NotImplementedException();
        }

        public void SetPageLayout(IPageLayout logic)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string text)
        {
            throw new NotImplementedException();
        }
    }
}
