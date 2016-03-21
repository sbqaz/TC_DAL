using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficControl.DAL
{
    public sealed class TCApi : ITCApi
    {
        public TCApi() { }

        public bool LogIn(string email, string encryptedPassWord)
        {
            //Change to some API call
            if (email == "1234" && encryptedPassWord == "1234")
                return true;
            else
                return false;
        }
    }
}
