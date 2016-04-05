using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    public sealed class TCApi : ITCApi
    {
        private string _apiUrl = @"http://api.trafficcontrol.dk/";
        private string _token = null;

        public bool LogIn(string email, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));

            var client = new RestClient(_apiUrl + "token");
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
            var client = new RestClient(_apiUrl + "api/Values");
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
            throw new System.NotImplementedException();
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
