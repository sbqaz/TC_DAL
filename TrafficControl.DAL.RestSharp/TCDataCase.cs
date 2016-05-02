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
    public class TCDataCase : TCData<Case>
    {
        public TCDataCase()
        {
            LIB = new TCDataAcess() {ApiDirectory = "api/Case"};
        }
        public override bool Post(Case obj)
        {
            if (obj.InstallationsID == 0) return false;
            var response = LIB.TCAPIconnection(Method.PUT,0,obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public override bool Update(Case user)
        {
            if (user == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, user.Id, user);
            return response.StatusCode == HttpStatusCode.OK;
        }
 
    }
    
}
