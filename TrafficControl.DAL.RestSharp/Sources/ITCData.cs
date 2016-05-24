using System.Collections.Generic;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// interface for dataservice klasser
    /// </summary>
    /// <typeparam name="T">typen for de diverse dataservice klasser </typeparam>
    public interface ITCData<T>
    {
        ITCDataConnection LIB { get; set; }
        T Get(long id = 0);
        ICollection<T> Get();
        bool Update(T user);
        bool Post(T obj);
    }
}