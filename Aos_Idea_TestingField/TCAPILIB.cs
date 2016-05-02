using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    public class TCAPILIB
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

    }
}
