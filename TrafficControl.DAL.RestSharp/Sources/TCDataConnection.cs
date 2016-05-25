using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// en Connection klasse med wrapups til forbindelse til API kald, og til at få en token fra WEB API 
    /// </summary>
    public class TCDataConnection : ITCDataConnection
    {
        /// <summary>
        ///     Konstructor
        /// </summary>
        public TCDataConnection()
        {
            ApiDirectory = "";
        }

        /// <summary>
        ///     Store for the url
        /// </summary>
        public static string ApiUrl { get; } = @"https://api.trafficcontrol.dk/";

        /// <summary>
        ///     Store for the Token
        /// </summary>
        public static string Token { get; set; }

        /// <summary>
        ///     Store for the subdirection example.com/(...)
        /// </summary>
        public string ApiDirectory { get; set; }

        /// <summary>
        ///     function til at tilgå web api 
        /// </summary>
        /// <param name="b">HTTP requests som METHOD.POST ect. </param>
        /// <param name="c"> hvis man vil connect til et specifik id til webapi </param>
        /// <param name="d">hvis man skal sende et objekt med sit api kald</param>
        /// <returns> RestResponse med alle de infomationer man skal bruge!</returns>
        public IRestResponse TCAPIconnection(Method b, long c=0, object d = null)
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
        ///     function til at tilgå web api
        /// </summary>
        /// <param name="b">HTTP requests som METHOD.POST ect. </param>
        /// <param name="c"> et objekt man kan sene til web api</param>
        /// <returns> RestResponse med alle de infomationer man skal bruge!</returns>
        public IRestResponse TCAPIconnection(Method b, string c)
        {
            var client = c == "" ? new RestClient(ApiUrl + ApiDirectory) : new RestClient(ApiUrl + ApiDirectory + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", Token);
            var response = client.Execute(request);
            return response;
        }

        /// <summary>
        ///     function til at tilgå web api
        /// </summary>
        /// <param name="ApiSubDirectory"> til mere customize api url .../xxx </param>
        /// <param name="b">HTTP requests som METHOD.POST ect. </param>
        /// <param name="c"> et objekt man kan sene til web api</param>
        /// <returns> RestResponse med alle de infomationer man skal bruge!</returns>
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
        ///     function til at tilgå web api
        /// </summary>
        /// <param name="ApiSubDirectory"> til mere customize api url .../xxx </param>
        /// <param name="b">HTTP requests som METHOD.POST ect. </param>
        /// <param name="c">valgfri, ellers er det til en specifik id man vil have connection til </param>
        /// <returns> RestResponse med alle de infomationer man skal bruge!</returns>
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
        /// Bruges til at få en token derefter gemmer den i static property
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <remarks>Kunne lægges over i User</remarks>
        /// <returns> If succes then True else false</returns>

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