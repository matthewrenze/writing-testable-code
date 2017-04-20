using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module4.Shared
{
    public class IdentityService : IIdentityService
    {
        public string GetUserName()
        {
            throw new NotImplementedException();
        }
    }
}
