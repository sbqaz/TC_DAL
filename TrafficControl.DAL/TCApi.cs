using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TrafficControl.DAL.Types;

namespace TrafficControl.DAL
{
    public sealed class TCApi : ITCApi
    {
        public TCApi() { }

        public bool LogIn(string email, string PassWord)
        {

            //Change to some API call
            using (var client = new HttpClient())
            {
                //ask bork what our url is  
                client.BaseAddress = new Uri("http://localhost:9000/");
                //client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                User usr = new User() {email = email, pass = PassWord};
                var resp = client.PostAsJsonAsync("api/Login",usr).Result;
                if (resp.IsSuccessStatusCode == true)
                    return true;
                else
                    return false; 
                        
                var response = client.GetAsync("api/Login").Result;
                response.EnsureSuccessStatusCode();
                

    }

            //if (email == "1234" && encryptedPassWord == "1234")
            //    return true;
            //else
            //    return false;
        }
    }
}
