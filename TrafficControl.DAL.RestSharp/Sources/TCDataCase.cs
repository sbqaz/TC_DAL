using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// Denne klasse har ansvar for at API kald der omhandler Position
    /// </summary>
    /// <remarks>nedarvet fra TCDATA<list type="Case"></list></remarks>
    public class TCDataCase : TCData<Case>
    {
        /// <summary>
        /// sætter api url til det rigtige
        /// </summary>
        public TCDataCase()
        {
            LIB = new TCDataConnection {ApiDirectory = "api/Case/"};
        }
        /// <summary>
        /// kalder GetMyCases();
        /// </summary>
        public ICollection<Case> MyCases => GetMyCases();

        /// <summary>
        /// Opretter et case
        /// </summary>
        /// <param name="obj"> et DTO objekt</param>
        /// <returns>True på Success, else False</returns>
        public bool Post(PostCaseDTO obj)
        {
            if (obj.Installation == 0) return false;
            var response = LIB.TCAPIconnection(Method.POST, 0, obj);
            return response.StatusCode == HttpStatusCode.Created;
        }
        /// <summary>
        ///  Opretter et case
        /// </summary>
        /// <param name="ErrorDescription"></param>
        /// <param name="Installationid"></param>
        /// <param name="Observer"></param>
        /// <returns>True på Success, else False</returns>
        public bool Post(string ErrorDescription, long Installationid, ObserverSelection Observer)
        {
            var obj = new PostCaseDTO() {ErrorDescription = ErrorDescription,Installation = Installationid,Observer = Observer};
            var response = LIB.TCAPIconnection(Method.POST, 0, obj);
            return response.StatusCode == HttpStatusCode.Created;
        }
        /// <summary>
        /// overskriver en eksisterende case med ny case
        /// </summary>
        /// <param name="obj">den nye Case man overskriver med</param>
        /// <returns>True på Success, else False</returns>
        public override bool Update(Case obj)
        {
            if (obj == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.Created;
        }
        /// <summary>
        /// Siger til Web API at man påtager sige en case, og tildeler den udfra ens token.
        /// </summary>
        /// <param name="id">Hvilke case man påtager sig</param>
        /// <returns>True på Success, else False</returns>
        public bool ClaimCase(long id)
        {
            if (id == 0) return false;
            var client = new RestClient(string.Format(@"https://api.trafficcontrol.dk/api/Case/ClaimCase?id={0}", id));
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", TCDataConnection.Token);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
        /// <summary>
        /// Siger til Web API at man påtager sige en case, og tildeler den udfra ens token.
        /// </summary>
        /// <param name="id">Hvilke case man påtager sig</param>
        /// <returns>True på Success, else False</returns>
        public ICollection<Case> GetMyCases()
        {
            var response = LIB.TCAPIconnection("MyCases/", Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return new Case[0];
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }


    }
}