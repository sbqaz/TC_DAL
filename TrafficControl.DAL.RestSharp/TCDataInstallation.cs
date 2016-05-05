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
    public class TCDataInstallation : TCData<Installation>
    {
        public TCDataInstallation()
        {
            LIB = new TCDataConnection() {ApiDirectory = "api/Installation"};
        }
        public override bool Post(Installation obj)
        {
            if (obj != null) return false;
            var response = LIB.TCAPIconnection(Method.POST, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public override bool Update(Installation user)
        {
            if (user == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, user.Id, user);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
