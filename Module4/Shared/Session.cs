using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module4.Shared
{
    public class Session : ISession
    {
        private readonly Login _login;

        public Session(Login login)
        {
            _login = login;
        }

        public Login GetLogin()
        {
            return _login;
        }
    }
}
