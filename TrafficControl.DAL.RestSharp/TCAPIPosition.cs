using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public class TCAPIPosition : TCAPILIB, IPosition
    {
        public Position GetPosition(int id = 0)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Position> GetPositions()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePosition()
        {
            throw new NotImplementedException();
        }
    }
    
    public class TCAPILIB
    {
        private string ApiUrl = "dfsda";
        private string _token = "sdas";
        public IRestResponse TCAPIconnection(string a, Method b, int c = 0, object d = null)
        {
            var client = c == 0 ? new RestClient(ApiUrl + a) : new RestClient(ApiUrl + a + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", _token);
            if (d != null)
            {
                request.AddJsonBody(d);
            }
            var response = client.Execute(request);
            return response;
        }
        // ReSharper disable once InconsistentNaming
        public IRestResponse TCAPIconnection(string a, Method b, string c)
        {
            var client = c == "" ? new RestClient(ApiUrl + a) : new RestClient(ApiUrl + a + c);
            var request = new RestRequest(b);
            request.AddHeader("Authorization", _token);
            var response = client.Execute(request);
            return response;
        }

    }
}
