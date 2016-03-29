namespace TrafficControl.DAL
{
    public interface ITCApi
    {
        bool LogIn(string email, string encryptedPassWord);
        void CreateUser();
        void UpdateUser();
        void deleteUser(); 
    }
}