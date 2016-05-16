using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public interface ITCData<T>
    {
        ITCDataConnection LIB { get; set; }
        T Get(long id=0);
        ICollection<T> GetAll();
        bool Update(T user);
        bool Post(T obj);
    }
}
