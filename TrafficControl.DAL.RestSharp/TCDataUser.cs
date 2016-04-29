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

    internal class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
    }

    internal class ChangePasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UpdateUserInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailNotification { get; set; }
        public bool SMSNotification { get; set; }
    }

    public class TCDataUser : ITCData<User>
    {
        public TCAPILIB LIB { get; set; }

        public TCDataUser()
        {
            LIB = new TCAPILIB() { ApiDirectory = "api/Account/" };
        }
        public bool Post(string email, string password, string confirmedpassword, string firstname, string lastname, int roles, string number)
        {
            var transferOjbectToWebApi = new AccountDTO()
            {
                ConfirmPassword = confirmedpassword,
                Email = email,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                Role = roles,
                PhoneNumber = number
            };
            var response = LIB.TCAPIconnection("Register", Method.POST, transferOjbectToWebApi);
            return response.StatusCode == HttpStatusCode.OK;
        }
        public bool ChangePassword(string oPassword, string nPassword, string cPassword)
        {
            var myRequestFormatInJsonThatNeedToBeFeedToWebApi = new ChangePasswordDTO()
            {
                OldPassword = oPassword,
                NewPassword = nPassword,
                ConfirmPassword = cPassword
            };
            var response = LIB.TCAPIconnection("ChangePassword", Method.PUT, myRequestFormatInJsonThatNeedToBeFeedToWebApi);
            return response.StatusCode == HttpStatusCode.OK;

        }
        public User Get(int id = 0)
        {
            var response = LIB.TCAPIconnection("UserInfo", Method.GET);
            var retval = JsonConvert.DeserializeObject<User>(response.Content);
            return retval;
        }
        public ICollection<User> GetAll()
        {
            var response = LIB.TCAPIconnection("UserInfo", Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<User>>(response.Content);
            return retval;
        }
        public ICollection<User> Get()
        {
            var response = LIB.TCAPIconnection("UserInfo", Method.GET);
            var retval = JsonConvert.DeserializeObject<ICollection<User>>(response.Content);
            return retval;
        }
        public bool Update(User User)
        {
            var tmp = new UpdateUserInfoDTO()
            {
                EmailNotification = User.EmailNotification,
                FirstName = User.FirstName,
                LastName = User.LastName,
                PhoneNumber = User.Number,
                SMSNotification = User.SMSNotification
            };
            
            //if (User == null) return false;
            var response = LIB.TCAPIconnection("UserInfo",Method.PUT, tmp);
            return response.StatusCode == HttpStatusCode.OK;

        }
        //TODO DELETE THIS!!!!
        public bool Post(User obj)
        {
            return false;
        }
        public bool Delete(int id)
        {
            if (id == 0) return false;
            var response = LIB.TCAPIconnection(Method.DELETE, id);
            return response.StatusCode == HttpStatusCode.OK;
        }





    }

}
