using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module5.Easy
{
    public interface ISecurity
    {
        string GetUserName();

        bool IsAdmin();
    }
}
