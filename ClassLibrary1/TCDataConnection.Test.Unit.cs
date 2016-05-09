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
            var mytest = TCDataConnection.LogIn("test@trafficcontrol.dk","Phantom-161");
            Assert.That(mytest,Is.EqualTo(true));
        }
        [Test]
        public void Login_WithValidLogin_TokenNotEmpty()
        {
            TCDataConnection.LogIn("test@trafficcontrol.dk", "Phantom-161");
            Assert.That(TCDataConnection.Token, Is.Not.Empty);
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
            TCDataConnection.LogIn("test", "tester");
            Assert.That(TCDataConnection.Token, Is.Empty);
        }

        [Test]
        public void TCAPIconnection_CallWithSomethingWierd_ReturnFalse()
        {

        }
        #region TCAPIConnection with Case
        #endregion
        #region TCAPIConnection with Postion

        #endregion
        #region TCAPIConnection with User
        #endregion
        #region TCAPIConnection with Installation
        #endregion
    }
}
