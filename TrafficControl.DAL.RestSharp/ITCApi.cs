using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;
namespace TrafficControl.DAL.RestSharp
{
    public interface ITCApi
    {
    #region Account
        bool LogIn(string email, string encryptedPassWord);

        bool CreateUser(string email, string password, string confirmedpassword, string firstname, string lastname,
            int roles, string number);
        bool CreateUser(User usr);
        bool ChangePassword(string oPassword, string nPassword , string cPassword);
        User GetUser();
        bool UpdateUser(User usr);
        bool UpdateUser(string email, string password, string name, bool smsNotification, bool emailnotifikation);
        bool DeleteUser(int id);
        #endregion
    #region Cases
        ICollection<Case> GetMyCases();
        Case GetCase(int id);
        bool CreateCase(int installtionId, ObserverSelection observer, string errorDescription);
        bool DeleteCase(int id);
        bool UpdateCase(Case myCase);
        ICollection<Case> GetCases();
        #endregion
        #region Installations
        ICollection<Installation> GetInstallations();
        Installation GetInstallation(int id);
        bool DeleteInstallation(int id);
        bool UpdateInstalltion(Installation obj);
        #endregion
    #region Position
        ICollection<Position> GetPositions();
        Position GetPosition(int id);
        bool DeletePosition(int id);
        bool UpdatePosition(Position position);
        #endregion
    }
}