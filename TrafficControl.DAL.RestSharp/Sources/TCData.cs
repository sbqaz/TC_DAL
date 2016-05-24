using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace TrafficControl.DAL.RestSharp
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// en abstrakt klasse til håndtering af APIKald
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TCData<T> : ITCData<T>
        where T : class, new()
    {
        /// <summary>
        /// gemmer en object med API kaldene.
        /// </summary>
        public ITCDataConnection LIB { get; set; }
        /// <summary>
        /// Base klassens API til post
        /// </summary>
        /// <remarks>
        /// kan overskrives..
        /// </remarks>
        /// <param name="obj">det object man har lyst til at oprette</param>
        /// <returns></returns>
        public virtual bool Post(T obj)
        {
            var response = LIB.TCAPIconnection(Method.POST, 0, obj);
            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// API kald til at opdatere med, nedarvet klasser kan lave en overskrivning hvis de skla bruge update 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>False</returns>
        public virtual bool Update(T user)
        {
            return false;
        }
        /// <summary>
        /// At få en specifik object
        /// </summary>
        /// <param name="id">id på det given object</param>
        /// <returns>Et object</returns>
        public virtual T Get(long id)
        {
            if (id == 0) return new T();
            var response = LIB.TCAPIconnection(Method.GET, id);
            if (response.StatusCode != HttpStatusCode.OK) return new T();
            var retval = JsonConvert.DeserializeObject<T>(response.Content);
            return retval;
        }

        /// <summary>
        /// Giver en Liste af objekter
        /// </summary>
        /// <returns>List<T></returns>
        public virtual ICollection<T> Get()
        {
            var response = LIB.TCAPIconnection(Method.GET);
            if (response.StatusCode != HttpStatusCode.OK) return new T[0];
            var retval = JsonConvert.DeserializeObject<ICollection<T>>(response.Content);
            return retval;
        }

        //public virtual bool Post(string email, string password, string confirmedpassword, string firstname,
        //    string lastname,
        //    int roles, string number)
        //{
        //    return false;
        //}
    }
}