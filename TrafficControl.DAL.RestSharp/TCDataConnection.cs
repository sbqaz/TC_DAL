using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    public class TCDataConnection
    {
        public static string ApiUrl { get; set; }
        public static string Token { get; set; }
        public string ApiDirectory { get; set; }
        public IRestResponse TCAPIconnection( Method b, long c = 0, object d = null)
        {
            var client = c == 0 ? new RestClient(ApiUrl + ApiDirectory) : new RestClient(ApiUrl + ApiDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            if (d != null)
            {
                request.AddJsonBody(d);
            }
            var response = client.Execute(request);
            return response;
        }
        // ReSharper disable once InconsistentNaming
        public IRestResponse TCAPIconnection( Method b, string c)
        {
            var client = c == "" ? new RestClient(ApiUrl + ApiDirectory) : new RestClient(ApiUrl + ApiDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, object c)
        {
            var client = new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            request.AddJsonBody(c);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, int c = 0)
        {
            var client = c == 0 ? new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory) : new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            request.AddJsonBody(c);
            var response = client.Execute(request);
            return response;
        }

        public static bool LogIn(string email, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));

            var client = new RestClient(TCDataConnection.ApiUrl + "token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            string tmp = String.Format("grant_type=password&userName={0}&password={1}", email, password);
            request.AddParameter("application/x-www-form-urlencoded", tmp, ParameterType.RequestBody);

            var response = client.Execute(request);

            var retval = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var _token = retval["token_type"] + " " + retval["access_token"];
                TCDataConnection.Token = _token;
                return true;
            }
            return false;

        }

    }
}
