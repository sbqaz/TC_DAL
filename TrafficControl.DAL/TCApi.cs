using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TrafficControl.DAL.Types;

namespace TrafficControl.DAL
{
    public sealed class TCApi : ITCApi
    {

        public bool LogIn(string email, string PassWord)
        {

            //Change to some API call
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://60.sv2.dk/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                User usr = new User() {username = email, password = PassWord};
                // maybe 
                //client.GetAsync("api/Login");
                var resp = client.PostAsJsonAsync("api/Login",usr).Result;

                return resp.IsSuccessStatusCode; 

            }
         
            //if (email == "1234" && encryptedPassWord == "1234")
            //    return true;
            //else
            //    return false;
       }
      // username" : "mb @wnb.dk", "password" : "1234", "name" : "Morten Bork", "privileges" : "20
        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://60.sv2.dk/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                User usr = new User() { username = email, password = passWord, name  = name, privileges = privileges};
                var resp = client.PostAsJsonAsync("api/User", usr).Result;
                return resp.IsSuccessStatusCode;
                //return int.Parse(resp.StatusCode.ToString());
            }
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://60.sv2.dk/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                User usr = new User() { username = email, password = passWord, name = name, privileges = privileges, id = id};
                var resp = client.PutAsJsonAsync("api/User", usr).Result;
                //return int.Parse(resp.StatusCode.ToString());
                return resp.IsSuccessStatusCode;
                
            }
        }

        public bool deleteUser(int id)
        {
            using (var client = new HttpClient())
            {
                //ask bork what our url is  
                client.BaseAddress = new Uri("http://60.sv2.dk/");
                //client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
                var resp = client.DeleteAsync("api/User/" + id).Result;
                return resp.IsSuccessStatusCode; 

                //var response = client.GetAsync("api/Login").Result;
                //response.EnsureSuccessStatusCode();


            }
        }
    }
}
