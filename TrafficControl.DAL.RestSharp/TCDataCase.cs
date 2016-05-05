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
        public ICollection<Case> MyCases => GetMyCases();

        public TCDataCase()
        {
            LIB = new TCDataConnection() {ApiDirectory = "api/Case/"};
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

        public bool ClaimCase(int id)
        {
            if (id == 0) return false;
            var response = LIB.TCAPIconnection("ClaimCase/",Method.PUT, id);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public ICollection<Case> GetMyCases()
        {
            var response = LIB.TCAPIconnection("MyCases/",Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }
        public override Case Get(int id)
        {
            if (id != 0)
            {
                return base.Get(id);
            }
            throw new ArgumentException("id shouldn't be zero");
        }
        public ICollection<Case> Get()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;

        }

        public override ICollection<Case> GetAll()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<ICollection<Case>>(response.Content);
            return retval;
        }
    }
}
