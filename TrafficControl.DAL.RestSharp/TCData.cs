using System.Collections.Generic;

namespace TrafficControl.DAL.RestSharp
{
    public abstract class TCData<T> : ITCData<T>
    {
        public TCAPILIB LIB { get; set; }
        public virtual T Get(int id = 0)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Post(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}