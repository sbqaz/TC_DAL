using System.Collections.Generic;
using System.ComponentModel;
using TrafficControl.DAL.RestSharp.Types;
namespace TrafficControl.DAL.RestSharp
{
    public interface ITCApi
    {
        bool LogIn(string email, string encryptedPassWord);
        bool CreateUser(string email, string passWord, string name, int privileges, string number);
        bool UpdateUser(string email, string passWord, string name, int privileges, int id);
        bool deleteUser(int id);
        bool ChangePassword(string Opassword, string NPassword);
        ICollection<Case> GetCases();

        Case GetCase(int caseId);
    }
}