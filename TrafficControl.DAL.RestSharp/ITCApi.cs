namespace TrafficControl.DAL.RestSharp
{
    public interface ITCApi
    {
        bool LogIn(string email, string encryptedPassWord);
        bool CreateUser(string email, string passWord, string name, int privileges);
        bool UpdateUser(string email, string passWord, string name, int privileges, int id);
        bool deleteUser(int id); 
    }
}