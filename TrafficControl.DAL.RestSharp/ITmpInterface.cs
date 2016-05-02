namespace TrafficControl.DAL.RestSharp
{
    public interface ITmpInterface
    {
        bool Post(string email, string password, string confirmedpassword, string firstname, string lastname,
   int roles, string number);
    }
}