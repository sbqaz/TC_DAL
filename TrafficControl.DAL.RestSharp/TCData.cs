using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public class TCData<T> : ITCData<T>
    {
        private TCAPILIB _myLIB;

        public TCData(string apiDirectory="")
        {
            _myLIB = apiDirectory=="" ? new TCAPILIB() { ApiDirectory = "api/Account" } : new TCAPILIB() { ApiDirectory = apiDirectory };
        }

        public ICollection<T> GetAll()
        {
            var response = _myLIB.TCAPIconnection(Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<T>>(response.Content);
            return retval;
        }

        public bool Update(T obj)
        {
            return false;
        }

        public T Get(int id)
        {
            var response = _myLIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<T>(response.Content);
            return retval;

        }


        public bool Delete(int id)
        {
            if (id == 0) return false;
            var response = _myLIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool Update(Position obj)
        {
           
                if (obj == null) return false;
                var response = _myLIB.TCAPIconnection(Method.PUT, obj.Id, obj);
                return response.StatusCode == HttpStatusCode.OK;
        }
        public bool Update(Case obj)
        {

            if (obj == null) return false;
            var response = _myLIB.TCAPIconnection(Method.PUT, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public bool Update(User obj)
        {

            if (obj == null) return false;
            var response = _myLIB.TCAPIconnection(Method.PUT,0, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public bool Update(Installation obj)
        {

            if (obj == null) return false;
            var response = _myLIB.TCAPIconnection(Method.PUT, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }


    }
}
