using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TrafficControl.DAL.RestSharp;

namespace DAL.Test.Unit
{
    
    [TestFixture]
    public class TCDataConnectionTests
    {
        private TCDataConnection uut { get; set; }

        [SetUp]
        public void Init()
        {
            uut = new TCDataConnection();
        }
        
    }
}
