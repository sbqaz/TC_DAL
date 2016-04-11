using System;

namespace TrafficControl.DAL.RestSharp
{
    public class TCAPIdummy: ITCApi
    {
        public bool LogIn(string email, string encryptedPassWord)
        {
            return true; 
        }

        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            return true; 
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            throw new NotImplementedException();
        }

        public bool deleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string Opassword, string NPassword)
        {
            throw new NotImplementedException();
        }
    }
}
