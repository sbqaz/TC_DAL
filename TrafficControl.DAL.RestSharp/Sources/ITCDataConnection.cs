using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface ITCDataConnection
    {
        string ApiDirectory { get; set; }
        IRestResponse TCAPIconnection(Method b, string c);
        IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, object c);
        IRestResponse TCAPIconnection(string ApiSubDirectory, Method b, int c = 0);
        IRestResponse TCAPIconnection(Method b, long c = 0, object d = null);
    }
}