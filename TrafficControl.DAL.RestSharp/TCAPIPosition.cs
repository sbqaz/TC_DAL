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
    public class TCAPIPosition : IPosition
    {
        private TCAPILIB _myLIB;

        public TCAPIPosition()
        {
            _myLIB = new TCAPILIB() {ApiDirectory = "api/position"};
        }
        public ICollection<Position> GetPositions()
        {
            var response = _myLIB.TCAPIconnection(Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<Position>>(response.Content);
            return retval;
        }

        public Position GetPosition(int id)
        {
            var response = _myLIB.TCAPIconnection( Method.GET, id);
            var retval = JsonConvert.DeserializeObject<Position>(response.Content);
            return retval;
        }

        
        public bool DeletePosition(int id)
        {
            if (id == 0) return false;
            var response = _myLIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool UpdatePosition(Position position)
        {
            if (position == null) return false;
            var response = _myLIB.TCAPIconnection(Method.PUT, position.Id, position);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
    
}
