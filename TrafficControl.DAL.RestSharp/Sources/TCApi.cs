using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// klassen samler og kalder funktioner der er implementeret i de andre TCData klasser
    /// </summary>
    /// <remarks> alle funktioner i denne klasser kalder videre p� en funktion og returnere hvad den kaldte funktion returnerer</remarks>
    public sealed class TCApi : ITCApi
    {
        #region Setup
        /// <summary>
        /// Base url til web api
        /// </summary>
        private const string ApiUrl = @"https://api.trafficcontrol.dk/";
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        /// <summary>
        /// til at holde en token
        /// </summary>
        private string _token = null;

        /// <summary>
        /// property til at holde en objekt der h�ndter Position relateret API kald
        /// </summary>
        public ITCData<Position> PositionDataHandler { get; set; }
        /// <summary>
        /// property til at holde en objekt der h�ndter Installation relateret API kald
        /// </summary>
        public ITCData<Installation> InstallationDataHandler { get; set; }
        /// <summary>
        /// property til at holde en objekt der h�ndter User relateret API kald
        /// </summary>
        public TCDataUser UserDataHandler { get; set; }
        /// <summary>
        /// property til at holde en objekt der h�ndter Case relateret API kald
        /// </summary>
        public TCDataCase CaseDataHandler { get; set; }

        /// <summary>
        /// Initialisering
        /// </summary>
        public TCApi()
        {
            PositionDataHandler = new TCDataPosition();
            UserDataHandler = new TCDataUser();
            CaseDataHandler = new TCDataCase();
            InstallationDataHandler = new TCDataInstallation();
            //TCDataConnection.ApiUrl = ApiUrl;
            TCDataConnection.Token = _token;
        }

        #endregion

        #region Account

        public bool LogIn(string email, string password)
        {
            return TCDataConnection.LogIn(email, password);
        }


        public bool ChangePassword(string opassword, string nPassword, string cPassword)
        {
            return UserDataHandler.ChangePassword(opassword, nPassword, cPassword);
        }

        #endregion

        #region Cases

        public ICollection<Case> GetMyCases()
        {
            return CaseDataHandler.MyCases;
        }

        public Case GetCase(long id)
        {
            return CaseDataHandler.Get(id);
        }

        public ICollection<Case> GetCases()
        {
            return CaseDataHandler.Get();
        }

        public bool ClaimCase(long id)
        {
            return CaseDataHandler.ClaimCase(id);
        }

        public bool CreateCase(long installtionID, ObserverSelection observer, string errorDescription)
        {
            var myCase = new PostCaseDTO
            {
                Installation = installtionID,
                Observer = observer,
                ErrorDescription = errorDescription
            };
            return CaseDataHandler.Post(myCase);
        }


        public bool UpdateCase(Case myCase)
        {
            return CaseDataHandler.Update(myCase);
        }

        #endregion

        #region Installations

        public ICollection<Installation> GetInstallations()
        {
            return InstallationDataHandler.Get();
        }

        public Installation GetInstallation(long id)
        {
            return InstallationDataHandler.Get(id);
        }


        public bool UpdateInstalltion(Installation obj)
        {
            return InstallationDataHandler.Update(obj);
        }

        #endregion

        #region Position

        public bool CreatePosition(double x, double y)
        {
            var myPosition = new Position
            {
                Latitude = x,
                Longtitude = y
            };
            return PositionDataHandler.Post(myPosition);
        }

        public ICollection<Position> GetPositions()
        {
            return PositionDataHandler.Get();
        }

        public Position GetPosition(long id)
        {
            return PositionDataHandler.Get(id);
        }


        public bool UpdatePosition(Position position)
        {
            return PositionDataHandler.Update(position);
        }

        #endregion

        #region Users

        public bool CreateUser(string email, string password, string confirmedpassword, string firstname,
            string lastname,
            int roles, string number)
        {
            return UserDataHandler.Post(email, password, confirmedpassword, firstname, lastname, roles, number);
        }

        public bool CreateUser(User usr)
        {
            return UserDataHandler.Post(usr);
        }

        public User GetUser()
        {
            return UserDataHandler.Get(0);
        }


        public bool UpdateUser(string firstname, string lastname, string number, bool smsNotification,
            bool emailNotification)
        {
            var usr = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Number = number,
                SMSNotification = smsNotification,
                EmailNotification = emailNotification
            };
            return UserDataHandler.Update(usr);
        }

        public bool UpdateUser(User usr)
        {
            return UserDataHandler.Update(usr);
        }

        #endregion
    }
}