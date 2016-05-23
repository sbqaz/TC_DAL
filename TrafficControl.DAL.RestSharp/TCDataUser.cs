﻿using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public class TCDataUser : TCData<User>
    {
        public TCDataUser()
        {
            LIB = new TCDataConnection {ApiDirectory = "api/Account/"};
        }


        //Account/Register

        public override bool Post(string email, string password, string confirmedpassword, string firstname,
            string lastname, int roles, string number)
        {
            var transferOjbectToWebApi = new AccountDTO
            {
                ConfirmPassword = confirmedpassword,
                Email = email,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                Role = roles,
                PhoneNumber = number
            };
            var response = LIB.TCAPIconnection("Register/", Method.POST, transferOjbectToWebApi);
            return response.StatusCode == HttpStatusCode.OK;
        }

        //Account/ChangePassword
        public bool ChangePassword(string oPassword, string nPassword, string cPassword)
        {
            var myRequestFormatInJsonThatNeedToBeFeedToWebApi = new ChangePasswordDTO
            {
                OldPassword = oPassword,
                NewPassword = nPassword,
                ConfirmPassword = cPassword
            };
            var response = LIB.TCAPIconnection("ChangePassword/", Method.POST,
                myRequestFormatInJsonThatNeedToBeFeedToWebApi);
            return response.StatusCode == HttpStatusCode.OK;
        }

        //GET api/Account/UserInfo
        public User Get(string id)
        {
            var response = LIB.TCAPIconnection("UserInfo/", Method.GET, id);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<User>(response.Content);
            return retval;
        }

        public override User Get(long id)
        {
            var response = LIB.TCAPIconnection("UserInfo/", Method.GET, id);
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var retval = JsonConvert.DeserializeObject<User>(response.Content);
            return retval;
        }

        public override bool Update(User user)
        {
            var tmp = new UpdateUserInfoDTO
            {
                EmailNotification = user.EmailNotification,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.Number,
                SMSNotification = user.SMSNotification
            };

            //if (User == null) return false;
            var response = LIB.TCAPIconnection("UserInfo/", Method.PUT, tmp);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool LogOut()
        {
            TCDataConnection.Token = string.Empty;
            var response = LIB.TCAPIconnection("Logout/", Method.POST);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}