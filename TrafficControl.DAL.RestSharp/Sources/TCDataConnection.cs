using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    ///     An Class responsible for the connection to API
    /// </summary>
    public class TCDataConnection : ITCDataConnection
    {
        /// <summary>
        ///     A Constructor
        /// </summary>
        public TCDataConnection()
        {
            ApiDirectory = "";
        }

        /// <summary>
        ///     Store for the url
        /// </summary>
        public static string ApiUrl { get; set; }

        /// <summary>
        ///     Store for the Token
        /// </summary>
        public static string Token { get; set; }

        /// <summary>
        ///     Store for the subdirection example.com/(...)
        /// </summary>
        public string ApiDirectory { get; set; }


        /// <summary>
        ///     One of the functions to access WEB API
        /// </summary>
        /// <param name="b">Set this to one of the HTTP requests like METHOD.POST ect. </param>
        /// <param name="c">optional parameter for id in API</param>
        /// <param name="d">optional parameter if you want to send an object</param>
        /// <returns>Returning a RestResponse Containing all the info you need!</returns>
        public IRestResponse TCAPIconnection(Method b, long c = 0, object d = null)
        {
            var client = c == 0 ? new RestClient(ApiUrl + ApiDirectory) : new RestClient(ApiUrl + ApiDirectory + c);
            var request = new RestRequest(b) {RequestFormat = DataFormat.Json};
            request.AddHeader("Authorization", Token);
            if (d != null)
            {
                //request.AddJsonBody(d);
                request.AddParameter("application/json", JsonConvert.SerializeObject(d), ParameterType.RequestBody);
            }

            var response = client.Execute(request);
            return response;
        }

        /// <summary>
        ///     One of the functions to access WEB API
        /// </summary>
        /// <param name="b">Set this to one of the HTTP requests like METHOD.POST ect. </param>
        /// <param name="c">optional parameter for id sometimes it's a string.. </param>
        /// <returns>Returning a RestResponse Containing all the info you need!</returns>
        public IRestResponse TCAPIconnection(Method b, string c)
        {
            var client = c == "" ? new RestClient(ApiUrl + ApiDirectory) : new RestClient(ApiUrl + ApiDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            var response = client.Execute(request);
            return response;
        }

        /// <summary>
        ///     One of the functions to access WEB API
        /// </summary>
        /// <param name="b">Set this to one of the HTTP requests like METHOD.POST ect. </param>
        /// <param name="c">the object you want to send </param>
        /// <param name="ApiSubDirectory">if you need a more speicialize .../xxx </param>
        /// <returns>Returning a RestResponse Containing all the info you need!</returns>
        public IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, object c)
        {
            var client = new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            request.AddJsonBody(c);
            var response = client.Execute(request);
            return response;
        }
        /// <summary>
        ///     One of the functions to access WEB API
        /// </summary>
        /// <param name="ApiSubDirectory">if you need a more speicialize .../xxx </param>
        /// <param name="b">Set this to one of the HTTP requests like METHOD.POST ect. </param>
        /// <param name="c">the specific id, otherwise just leave it be.. </param>
        /// <returns>Returning a RestResponse Containing all the info you need!</returns>
        public IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, int c = 0)
        {
            var client = c == 0
                ? new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory)
                : new RestClient(ApiUrl + ApiDirectory + ApiSubDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            request.AddJsonBody(c);
            var response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Used to retreve a access token then save it 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>returning true if succes and false if fail</returns>

        public static bool LogIn(string email, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));

            var client = new RestClient(ApiUrl + "token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            var tmp = string.Format("grant_type=password&userName={0}&password={1}", email, password);
            request.AddParameter("application/x-www-form-urlencoded", tmp, ParameterType.RequestBody);

            var response = client.Execute(request);

            var retval = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var _token = retval["token_type"] + " " + retval["access_token"];
                Token = _token;
                return true;
            }
            return false;
        }
    }
}