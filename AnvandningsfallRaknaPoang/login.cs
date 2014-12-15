using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvandningsfallRaknaPoang
{
    class login
    {
        private string _userN = "admin";
        private string _pass = "admin";

        public void loggingIn(string userN, string pass)
        {
            if (userN != _userN || pass != _pass)
            {                    
                throw new ArgumentException();
            }
            else
                    return;
        }
    }
}
