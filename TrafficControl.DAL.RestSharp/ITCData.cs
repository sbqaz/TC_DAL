using System.Collections.Generic;

namespace TrafficControl.DAL.RestSharp
{
    public interface ITCData<T>
    {
        ITCDataConnection LIB { get; set; }
        T Get(long id=0);
        //ICollection<T> GetAll();
        ICollection<T> Get();
        bool Update(T user);
        bool Post(T obj);
    }
}
