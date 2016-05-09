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
            TCDataConnection.ApiUrl = @"https://api.trafficcontrol.dk/";

        }

        [Test]
        public void Login_WithValidLogin_ReturnsTrue()
        {

        }
        [Test]
        public void Login_WithValidLogin_TokenNotEmpty()
        {

        }
        [Test]
        public void Login_WithInValidLogin_ReturnsFalse()
        {
            var mytest = TCDataConnection.LogIn("test", "tester");
            Assert.That(mytest,Is.EqualTo(false));
        }
        [Test]
        public void Login_WithInValidLogin_TokenEmpty()
        {

        }

        [Test]
        public void TCAPIconnection_Returns_okayish()
        {
            
        }
    }
}
