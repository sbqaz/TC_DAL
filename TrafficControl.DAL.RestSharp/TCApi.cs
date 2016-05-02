using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

//TODO Maybe I should use one of the solid principle to split the interface up?

namespace TrafficControl.DAL.RestSharp
{
    public sealed class TCApi : ITCApi
    {
        
        private const string ApiUrl = @"https://api.trafficcontrol.dk/";
        //private const string ApiUrl = @"localhost:49527/";
        private string _token = null;
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

<<<<<<< HEAD
            return TCDataAcess.LogIn(email, password);
        }

        public bool ChangePassword(string opassword, string nPassword,string cPassword)
        {
            return UserDataHandler.ChangePassword(opassword,nPassword,cPassword);

=======
            string tmp = String.Format("grant_type=password&userName={0}&password={1}", email, password);
            request.AddParameter("application/x-www-form-urlencoded", tmp, ParameterType.RequestBody);

            var response = client.Execute(request);

            var retval = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _token = retval["token_type"] + " " + retval["access_token"];
                TCAPILIB.Token = _token;
                return true;
            }
            return false;

        }


       
        
        
        public bool ChangePassword(string opassword, string nPassword)
        {
            var client = new RestClient(ApiUrl + "api/Account/ChangePassword");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"OldPassword\": \""+ opassword + "\",\r\n  \"NewPassword\": \""+ nPassword + "\",\r\n  \"ConfirmPassword\": \""+ nPassword + "\"\r\n}", ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
>>>>>>> refs/remotes/origin/master
        }
        
        #endregion
#region Cases
        public ICollection<Case> GetCases()
        {
            return CaseDataHandler.GetAll();
        }

        public Case GetCase(int id = 0)
        {
            return CaseDataHandler.Get(id);
        }

        public bool CreateCase(int InstalltionId, int observer, string errorDescription)
        {
            var myCase = new Case()
            {
                InstallationsID = InstalltionId,
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
        public bool CreateUser(string email, string passWord, string fullname, int privileges, string number)
<<<<<<< HEAD
=======
        {
            var str = fullname.Split(' ');
            return 
            TC.Post(email, passWord, passWord, str[0], str[1], privileges, number);
        }

        public bool CreateUser(string email, string passWord, string fullname, int privileges, string number, bool emailnotification = false, bool smsNotification = false)
        {
            var str = fullname.Split(' ');
            // var usr  = new User() { Password=passWord , Username = email , FirstName = str[0] ,LastName = str[1], Privileges = privileges, Number = number, EmailNotification = emailnotification, SMSNotification = smsNotification};
            var client = new RestClient(ApiUrl + "api/Account/Register");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token);

            //Temporary function
            request.AddParameter("application/json", "{\r\n  \"Email\": \"" + email + "\",\r\n  \"Password\": \"" + passWord + "\",\r\n      \"ConfirmPassword\": \"" + passWord + "\"\r\n}", ParameterType.RequestBody);
            //request.AddJsonBody(usr);

            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public bool CreateUser(string email, string password, string confirmedpassword, string firstname, string lastname, int roles, string number)
>>>>>>> refs/remotes/origin/master
        {
            var str = fullname.Split(' ');
            return 
            TC.Post(email, passWord, passWord, str[0], str[1], privileges, number);
        }


        public bool Post(string email, string password, string confirmedpassword, string firstname, string lastname,
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

        
        public bool UpdateUser( string firstname,string lastname,string number, bool SMSNotification , bool emailNotification)
        {
            var usr = new User()
            {
                 FirstName = firstname,LastName = lastname,Number = number,SMSNotification = SMSNotification,EmailNotification = emailNotification
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
