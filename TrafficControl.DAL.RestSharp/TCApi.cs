using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public sealed class TCApi : ITCApi
    {
        private const string ApiUrl = @"https://api.trafficcontrol.dk/";
        private string _token = null;

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
                return true;
            }
            return false;

        }

        public bool CreateUser(string email, string passWord, string name, int privileges,string number)
        {
            var usr  = new User() { password=passWord , username = email , name = name , privileges = privileges, number = number};
            var client = new RestClient(ApiUrl + "api/Account/Register");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token); 

            //Temporary function
            request.AddParameter("application/json", "{\r\n  \"Email\": \""+ email +"\",\r\n  \"Password\": \""+ passWord + "\",\r\n      \"ConfirmPassword\": \""+ passWord +"\"\r\n}", ParameterType.RequestBody);
            //request.AddJsonBody(usr);

            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK; 
        }
        
        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool deleteUser(int id)
        {
            var client = new RestClient(ApiUrl + "api/Account/");
            var request = new RestRequest(Method.POST);

            return true;
        }

        public bool ChangePassword(string oPassword, string nPassword)
        {
            var client = new RestClient(ApiUrl + "api/Account/ChangePassword");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"OldPassword\": \""+ oPassword + "\",\r\n  \"NewPassword\": \""+ nPassword + "\",\r\n  \"ConfirmPassword\": \""+ nPassword + "\"\r\n}", ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public ICollection<Case> GetCases()
        {
            var client = new RestClient(ApiUrl + "api/Cases");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);
            IRestResponse response = client.Execute(request);
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }

        public Case GetCase(int caseId)
        {
            var client = new RestClient(ApiUrl + "api/Cases/" + caseId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);
            IRestResponse response = client.Execute(request);
            var retval = JsonConvert.DeserializeObject<Case>(response.Content);
            Debug.Assert(retval != null, "retval != null");
            return retval;
        }

        ICollection<Installation> ITCApi.Installations()
        {
            var client = new RestClient(ApiUrl + "api/Installations");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);
            IRestResponse response = client.Execute(request);
            var retval = JsonConvert.DeserializeObject<ICollection<Installation>>(response.Content);
            return retval;
        }

        public Installation GetInstallation(int id)
        {
            var client = new RestClient(ApiUrl + "api/Installations" + id); 
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);
            IRestResponse response = client.Execute(request);
            var retval = JsonConvert.DeserializeObject<Installation>(response.Content);
            return retval;
        }
        
        public ICollection<Position> GetPositions()
        {
            throw new NotImplementedException();
        }

        public Position GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        private RestRequest TCAPIconnection(string a, Method b, int c = new int())
        {
            var client = new RestClient(ApiUrl + a + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", _token);
            return request;
        }
    }
}
