using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{

    public abstract class TCData<T> : ITCData<T>
        where T: class
    {
        public TCAPILIB LIB { get; set; }
        public virtual T Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<T>(response.Content);
            return retval;
        }

        public virtual bool Delete(int id)
        {
            if (id == 0) return false;
            var response = LIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public virtual ICollection<T> GetAll()
        {
            return null;
        }

        public abstract bool Update(T obj);

        public bool Post(T obj)
        {
            return false;
        }


    }

}