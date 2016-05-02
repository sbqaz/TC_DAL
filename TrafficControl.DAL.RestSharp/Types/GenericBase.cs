using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.DAL.RestSharp.Types
{
    public abstract class GenericBase<T> 
    {
        public abstract T Id { get; set; }
    }
}
