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
    public class TCDataInstallation : ITCData<Installation>
    {
        public TCAPILIB LIB { get; set; }

        public TCDataInstallation()
        {
            LIB = new TCAPILIB() {ApiDirectory = "api/Installation"};
        }
        public bool Post(Installation obj)
        {
            if (obj != null) return false;
            var response = LIB.TCAPIconnection(Method.POST, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public Installation Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<Installation>(response.Content);
            return retval;
        }
        public ICollection<Installation> GetAll()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Installation>>(response.Content);
            return retval;
        }

        public bool Update(Installation installation)
        {
            if (installation == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, installation.Id, installation);
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
