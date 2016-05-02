using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficControl.DAL.RestSharp.Types;

namespace Aos_Idea_TestingField
{
    class Program
    {
        static void Main(string[] args)
        {
            Test<Position,Installation,Case,User> test = new User();
        }
    }
}
