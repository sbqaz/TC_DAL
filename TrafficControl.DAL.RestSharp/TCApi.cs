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
        private IPosition MyPositionHandler { get; set; }
        TCApi()
        {
            TCAPILIB.ApiUrl = ApiUrl;
            TCAPILIB.Token = _token;
            MyPositionHandler = new TCAPIPosition();
        }
#region Account
        //Email: test@trafficcontrol.dk Password: Phantom-161
        public bool LogIn(string email, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));

            var client = new RestClient(ApiUrl + "token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

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


        public bool CreateUser(string email, string passWord, string fullname, int privileges, string number)
        {
            return CreateUser(email,passWord,fullname,privileges,number,false,false);
        }

        public bool CreateUser(string email, string passWord, string fullname, int privileges,string number, bool emailnotification = false, bool smsNotification = false)
        {
            var str = fullname.Split(' ');
           // var usr  = new User() { Password=passWord , Username = email , FirstName = str[0] ,LastName = str[1], Privileges = privileges, Number = number, EmailNotification = emailnotification, SMSNotification = smsNotification};
            var client = new RestClient(ApiUrl + "api/Account/Register");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token); 

            //Temporary function
            request.AddParameter("application/json", "{\r\n  \"Email\": \""+ email +"\",\r\n  \"Password\": \""+ passWord + "\",\r\n      \"ConfirmPassword\": \""+ passWord +"\"\r\n}", ParameterType.RequestBody);
            //request.AddJsonBody(usr);

            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK; 
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
        }
        
        #endregion
#region Cases
        public ICollection<Case> GetCases()
        {
            var response = TCAPIconnection("api/Case", Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }

        public Case GetCase(int id = 0)
        {
            var response = TCAPIconnection("api/Case", Method.GET,id);
            var retval = JsonConvert.DeserializeObject<Case>(response.Content);
            return retval;
        }

        public bool CreateCase(int Id, int InstalltionId, string worker, DateTime startTime, int observer, string errorDescription,
            string repair)
        {
            var myCase = new Case()
            {
                Id = Id,
                InstallationsID = InstalltionId,
                Worker = worker,
                Time = startTime,
                Observer = observer,
                ErrorDescription = errorDescription,
                MadeRepair = repair,
                Status = 0 
            };
           
            var response = TCAPIconnection("api/Case", Method.POST,0, myCase);
            return response.StatusCode == HttpStatusCode.OK;
        }
        

        public bool DeleteCase(int id)
        {
            var response = TCAPIconnection("api/Case", Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool UpdateCase(Case myCase)
        {
            var response = TCAPIconnection("api/Case", Method.PUT, Int32.Parse(myCase.Id.ToString()),myCase);
            return response.StatusCode == HttpStatusCode.OK;
        }

        #endregion
#region Installations
        public ICollection<Installation> GetInstallations()
        {
            var response = TCAPIconnection("api/Installations", Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Installation>>(response.Content);
            return retval;
        }

        public Installation GetInstallation(int id)
        {
            var response = TCAPIconnection("api/Installations", Method.GET, id);
            var retval = JsonConvert.DeserializeObject<Installation>(response.Content);
            return retval;
        }

        public bool DeleteInstallation(int id)
        {
            IRestResponse response;
            if (id == 0)
            {
                var usr = GetUser();
                response = TCAPIconnection("api/Installation", Method.DELETE, usr.Id);

            }
            else
            {
                response = TCAPIconnection("api/Installation", Method.DELETE, id);
            }
            return response.StatusCode == HttpStatusCode.OK;
        }


        public bool UpdateInstalltion()
        {
            throw new NotImplementedException();
        }


        #endregion
#region Position
        public ICollection<Position> GetPositions()
        {
            return MyPositionHandler.GetPositions();
        }

        public Position GetPosition(int id)
        {
            return MyPositionHandler.GetPosition(id);
        }

        public bool DeletePosition(int id)
        {
            return MyPositionHandler.DeletePosition(id);
        }

        public bool UpdatePosition(Position position)
        {
            return MyPositionHandler.UpdatePosition(position);
        }



        #endregion
#region Users


            
        public bool CreateUser(User usr)
        {
            var response = TCAPIconnection("api/User", Method.POST, 0, usr);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public User GetUser()
        {
            var response = TCAPIconnection("api/User", Method.GET);
            if (response.Content == "[]")
            {
                return null;
            }
            else
            {
                var retval = JsonConvert.DeserializeObject<List<User>>(response.Content);
                CurUser = retval[0];
                return CurUser;
            }
             
        }

        

        public bool UpdateUser(string email, string passWord, string name, int privileges, string id)
        {
            var str = name.Split(' ');
            var usr = new User() {FirstName = str[0], Id = id, LastName = str[1]};
            var response = TCAPIconnection("api/User", Method.PUT, 0, usr);
            //return response.StatusCode == HttpStatusCode.OK;
            return true;
        }
        public bool UpdateUser(User usr = null)
        {
            if (usr == null)
                usr = CurUser;
            var response = TCAPIconnection("api/User", Method.PUT, 0, usr);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool DeleteUser(int id = 0)
        {
            IRestResponse response;
            if (id == 0)
            {
                var usr = GetUser();
                response = TCAPIconnection("api/User", Method.DELETE, usr.Id);

            }
            else
            {
                response = TCAPIconnection("api/User", Method.DELETE, id);
            }
            return response.StatusCode == HttpStatusCode.OK;
        }

        #endregion
#region Helper functions
        // ReSharper disable once InconsistentNaming
        private IRestResponse TCAPIconnection(string a, Method b,long c = 0,object d = null)
        {
            var client = c == 0 ? new RestClient(ApiUrl + a) : new RestClient(ApiUrl + a + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", _token);
            if (d != null)
            {
                request.AddJsonBody(d);
            }
            var response = client.Execute(request);
            return response;
        }
        // ReSharper disable once InconsistentNaming
        private IRestResponse TCAPIconnection(string a, Method b, string c)
        {
            var client = c == "" ? new RestClient(ApiUrl + a) : new RestClient(ApiUrl + a + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", _token);
            var response = client.Execute(request);
            return response;
        }
        #endregion

    }
}
