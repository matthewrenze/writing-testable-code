using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module6.Shared
{
    public class Security : ISecurity
    {
        private string _userName;
        private bool _isAdmin;

        public void SetUser(string userName, bool isAdmin)
        {
            _userName = userName;

            _isAdmin = isAdmin;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public bool IsAdmin()
        {
            return _isAdmin;
        }
    }
}
