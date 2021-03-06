﻿using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// Denne klasse har ansvar for at API kald der omhandler User
    /// </summary>
    /// <remarks>nedarvet fra TCDATA<list type="User"></list></remarks>
    public class TCDataUser : TCData<User>
    {
        /// <summary>
        /// sætter suburl til det rigtige
        /// </summary>
        public TCDataUser()
        {
            LIB = new TCDataConnection {ApiDirectory = "api/Account/"};
        }


        /// <summary>
        /// Håndtere oprettelse af nye Bruger
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmedpassword"> skriv password igen </param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="roles"> 0/1/2 for de forskellige roller </param>
        /// <param name="number"> mobil- eller telefonnummer</param>
        /// <returns> True på Succes, else False </returns>
        public bool Post(string email, string password, string confirmedpassword, string firstname,
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
        /// <summary>
        /// bruges ikke
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>False</returns>
        public override bool Post(User obj)
        {
            return false;
        }

        /// <summary>
        /// Hvis man skal skifte kode
        /// </summary>
        /// <param name="oPassword"> den gamle kode</param>
        /// <param name="nPassword">den nye kode</param>
        /// <param name="cPassword">den nye kode</param>
        /// <returns> True på Succes, False på Failures </returns>
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

        /// <summary>
        /// giver spefik user 
        /// </summary>
        /// <param name="id"> id på given user</param>
        /// <returns>User object</returns>
        public User Get(string id)
        {   
            var response = LIB.TCAPIconnection("UserInfo/", Method.GET, id);
            if (response.StatusCode != HttpStatusCode.OK) return new User();
            var retval = JsonConvert.DeserializeObject<User>(response.Content);
            return retval;
        }
        /// <summary>
        /// Bruges ikke
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returner bare en tomt objekt</returns>
        public override User Get(long id)
        {
            return new User();
        }
        /// <summary>
        /// Bruges til opdatering a user
        /// </summary>
        /// <param name="user">et user objekt</param>
        /// <returns>True på Succes, False på Failure</returns>
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

            var response = LIB.TCAPIconnection("UserInfo/", Method.PUT, tmp);
            return response.StatusCode == HttpStatusCode.OK;
        }
        /// <summary>
        /// At logge ud på user
        /// </summary>
        /// <returns>True på Succes, False på Failure</returns>
        public bool LogOut()
        {
            TCDataConnection.Token = string.Empty;
            var response = LIB.TCAPIconnection("Logout/", Method.POST);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}