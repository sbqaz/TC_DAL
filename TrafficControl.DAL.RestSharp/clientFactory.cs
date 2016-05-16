using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    public class clientFactory
    {
        public RestClient getClient(string s)
        {
            return new RestClient(s);
        }
        public IRestClient getFakeClient(string s)
        {
            return new RestClient(s);
        }
    }
}
