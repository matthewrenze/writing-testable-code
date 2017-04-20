using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module3.Shared
{
    public interface IPrinter
    {
        void SetPageLayout(IPageLayout layout);

        void SetInkColor(string color);

        void WriteLine(string text);
    }
}
