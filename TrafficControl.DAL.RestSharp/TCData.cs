using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    // ReSharper disable once InconsistentNaming
    public abstract class TCData<T> : ITCData<T>
        where T : class
    {

        public TCDataConnection LIB { get; set; }


        //README if we want error checking, we can override this func
        public virtual bool Post(string email, string password, string confirmedpassword, string firstname, string lastname,
            int roles, string number)
        {
            return false;
        }
 
        public virtual bool Post(T obj)
        {
            var response = LIB.TCAPIconnection(Method.PUT, 0, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public abstract bool Update(T user);

        public virtual T Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<T>(response.Content);
            return retval;
        }

        public virtual bool Delete(int id)
        {
            if(id == 0) return false;
            var response = LIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }


        public virtual ICollection<T> GetAll() 
        {
            var response = LIB.TCAPIconnection(Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<ICollection<T>>(response.Content);
            return retval;
        }
            




    }

}