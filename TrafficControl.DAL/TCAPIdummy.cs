using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.DAL
{
    class TCAPIdummy: ITCApi
    {
        public bool LogIn(string email, string encryptedPassWord)
        {
            return true; 
        }

        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            throw new NotImplementedException();
        }

        public bool deleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
