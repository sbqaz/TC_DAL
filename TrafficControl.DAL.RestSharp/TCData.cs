using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public abstract class TCData<T> : ITCData<T>
    {
        public TCAPILIB LIB { get; set; }
        public virtual T Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<T>(response.Content);
            return retval;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var response = LIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public ICollection<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(T obj)
        {
            //if (T == null) return false;
            //var response = LIB.TCAPIconnection(Method.PUT, T.Id, T);
            //return response.StatusCode == HttpStatusCode.OK;
            return true;
        }

        public bool Post(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}