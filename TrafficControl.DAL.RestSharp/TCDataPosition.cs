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
    public class TCDataPosition : ITCData<Position>
    {
        public TCAPILIB LIB { get; set; }

        public TCDataPosition(string optional=null)
        {
            if (optional != null)
            {
                LIB = new TCAPILIB() {ApiDirectory = optional};
            }
            else
            {
                LIB = new TCAPILIB() {ApiDirectory = "api/position/"};
            }
        }
        public bool Post(Position obj)
        {
            if (obj == null) return false;
            var response = LIB.TCAPIconnection(Method.POST, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public Position Get(int id = 0)
        {
            var response = LIB.TCAPIconnection(Method.GET, id);
            var retval = JsonConvert.DeserializeObject<Position>(response.Content);
            return retval;
        }
        public ICollection<Position> GetAll()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Position>>(response.Content);
            return retval;
        }
        public bool Update(Position position)
        {
            if (position == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, position.Id, position);
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
