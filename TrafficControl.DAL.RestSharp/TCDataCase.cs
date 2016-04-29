using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public class TCDataCase : ITCData<Case>
    {
        public TCAPILIB LIB { get; set; }

        public TCDataCase()
        {
            LIB = new TCAPILIB() {ApiDirectory = "api/Case"};
        }
        public bool Post(Case obj)
        {
            throw new NotImplementedException();
        }
        public Case Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<Case>(response.Content);
            return retval;
        }
        public ICollection<Case> GetAll()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }
        public bool Update(Case Case)
        {
            if (Case == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, Case.Id, Case);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var response = LIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }



       
     
    }
    
}
