using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.DAL.RestSharp.Types
{
    //public abstract class GenericBase<T> : IMyInterface<T>
    //{
    //    public abstract T Id { get; set; }

    //    public void Test()
    //    {
    //        Console.Write("called");
    //    }
    //}

    //public interface IMyInterface<T>
    //{
    //    T Id { get; set; }
    //}
    public abstract class Test<P,I,C,U>
    where P: Position
    where I: Installation
    where C: Case
    where U: User
{
}
}
