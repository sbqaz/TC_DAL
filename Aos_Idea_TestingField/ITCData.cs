﻿using System;
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
        TCAPILIB LIB { get; set; }
        T Get(int id=0);
        bool Delete(int id);
        ICollection<T> GetAll();
        bool Update(T obj);
        bool Post(T obj);
    }
}
