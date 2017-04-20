using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module4.Shared
{
    public class User
    {
        private readonly string _userName;

        public User(string userName)
        {
            _userName = userName;
        }

        public string GetUserName()
        {
            return _userName;            
        }
    }
}
