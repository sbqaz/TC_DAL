using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public sealed class TCApi : ITCApi
    {
        private const string ApiUrl = @"http://api.trafficcontrol.dk/";
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

        public void PrintValues()
        {
            var client = new RestClient(ApiUrl + "api/Values");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", _token);

            var response = client.Execute<List<string>>(request);

            foreach (var s in response.Data)
            {
                //Console.WriteLine(s);
            }
        }

        
 

        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            var usr  = new User() { password=passWord , username = email , name = name , privileges = privileges};
            var client = new RestClient(ApiUrl + "api/Account/Register");
            var request = new RestRequest(Method.POST);
            
            //request.AddHeader("Authorization", _token);  - FIXME when we get auth in place
            request.AddJsonBody(usr);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK; 
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool deleteUser(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
