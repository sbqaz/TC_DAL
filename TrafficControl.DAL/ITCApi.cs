namespace TrafficControl.DAL
{
    public interface ITCApi
    {
        bool LogIn(string email, string encryptedPassWord);
    }
}