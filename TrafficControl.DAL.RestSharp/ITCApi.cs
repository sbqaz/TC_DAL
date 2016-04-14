using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;
namespace TrafficControl.DAL.RestSharp
{
    public interface ITCApi
    {
        bool LogIn(string email, string encryptedPassWord);
        bool CreateUser(string email, string passWord, string name, string privileges);
        bool UpdateUser(string email, string passWord, string name, string privileges, int id);
        bool deleteUser(int id);
        bool ChangePassword(string Opassword, string NPassword);
        ICollection<Case> GetCases();
    }
}