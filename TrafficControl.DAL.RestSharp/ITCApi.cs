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
        #endregion
    #region Cases
        ICollection<Case> GetMyCases();
        Case GetCase(long id);
        bool ClaimCase(long id);
        bool CreateCase(long installtionId, ObserverSelection observer, string errorDescription);
        bool UpdateCase(Case myCase);
        ICollection<Case> GetCases();
        #endregion
    #region Installations
        ICollection<Installation> GetInstallations();
        Installation GetInstallation(long id);
        bool UpdateInstalltion(Installation obj);
        #endregion
    #region Position
        ICollection<Position> GetPositions();
        Position GetPosition(long id);
        bool UpdatePosition(Position position);
        #endregion
    }
}