using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    // ReSharper disable once InconsistentNaming
    public sealed class TCApi : ITCApi
    {
        
        private const string ApiUrl = @"https://api.trafficcontrol.dk/";
        //private const string ApiUrl = @"localhost:49527/";
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private string _token = null;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private User CurUser { get; set; }
        public ITCData<Position> PositionDataHandler { get; set; }
        public TCData<User> UserDataHandler { get; set; }
        public ITCData<Installation> InstallationDataHandler { get; set; }
        public ITCData<Case> CaseDataHandler { get; set; }

        public TCApi()
        {
            PositionDataHandler = new TCDataPosition();
            UserDataHandler = new TCDataUser();
            CaseDataHandler = new TCDataCase();
            InstallationDataHandler = new TCDataInstallation();
            TCDataAcess.ApiUrl = ApiUrl;
            TCDataAcess.Token = _token;
        }
        #region Account
        //Email: test@trafficcontrol.dk Password: Phantom-161
        public bool LogIn(string email, string password)
        {
            return TCDataAcess.LogIn(email, password);
        }

        public bool ChangePassword(string opassword, string nPassword,string cPassword)
        {
            return UserDataHandler.ChangePassword(opassword,nPassword,cPassword);
        }
        
        #endregion
        #region Cases
        public ICollection<Case> GetMyCases()
        {
            return CaseDataHandler.GetAll();
        }

        public Case GetCase(int id = 0)
        {
            return CaseDataHandler.Get(id);
        }

        public bool CreateCase(int installtionId, ObserverSelection observer, string errorDescription)
        {
            var myCase = new Case()
            {
                InstallationsID = installtionId,
                Observer = observer,
                ErrorDescription = errorDescription,
                Status = 0 
            };
            return CaseDataHandler.Post(myCase);
        }

        public bool DeleteCase(int id)
        {
            return CaseDataHandler.Delete(id);
        }

        public bool UpdateCase(Case myCase)
        {
            return CaseDataHandler.Update(myCase);
        }

        #endregion
        #region Installations
        public ICollection<Installation> GetInstallations()
        {
            return InstallationDataHandler.GetAll();
        }

        public Installation GetInstallation(int id)
        {
            return InstallationDataHandler.Get(id);
        }

        public bool DeleteInstallation(int id)
        {
            return InstallationDataHandler.Delete(id);
        }


        public bool UpdateInstalltion(Installation obj)
        {
            return InstallationDataHandler.Update(obj);
        }


        #endregion
        #region Position
        public bool CreatePosition(double x, double y)
        {
            var myPosition = new Position()
            {
                Latitude = x,Longtitude = y
            };
            return PositionDataHandler.Post(myPosition);
        }
        public ICollection<Position> GetPositions()
        {
            return PositionDataHandler.GetAll();
        }

        public Position GetPosition(int id)
        {
            return PositionDataHandler.Get(id);
        }

        public bool DeletePosition(int id)
        {
            return PositionDataHandler.Delete(id);
        }

        public bool UpdatePosition(Position position)
        {
           return PositionDataHandler.Update(position);
        }

        #endregion
        #region Users
    
        public bool CreateUser(string email, string password, string confirmedpassword, string firstname, string lastname,
            int roles, string number)
        {
            return UserDataHandler.Post(email, password, confirmedpassword, firstname, lastname, roles,number);
        }

        public bool CreateUser(User usr)
        {
            return UserDataHandler.Post(usr);
        }

        public User GetUser()
        {
            return UserDataHandler.Get();
        }

        
        public bool UpdateUser( string firstname,string lastname,string number, bool smsNotification , bool emailNotification)
        {
            var usr = new User()
            {
                 FirstName = firstname,LastName = lastname,Number = number,SMSNotification = smsNotification,EmailNotification = emailNotification
            };
            return UserDataHandler.Update(usr);
        }
        public bool UpdateUser(User usr = null)
        {
            if (usr == null)
                usr = CurUser;
            return UserDataHandler.Update(usr);
        }

        public bool DeleteUser(int id = 0)
        {
            return UserDataHandler.Delete(id);
        }

        #endregion
    }
}
