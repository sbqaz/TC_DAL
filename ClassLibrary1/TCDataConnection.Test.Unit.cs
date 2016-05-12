using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using RestSharp;
using TrafficControl.DAL.RestSharp;

namespace DAL.Test.Unit
{
    
    [TestFixture]
    public class TCDataConnectionTests
    {
        private TCDataConnection uut { get; set; }
        private TCDataConnection uutWithPosition { get; set; }
        [SetUp]
        public void Init()
        {
            uut = new TCDataConnection();
            uutWithPosition = new TCDataConnection(){ApiDirectory = "api/Position/"};
            TCDataConnection.ApiUrl = @"https://api.trafficcontrol.dk/";

        }
        #region Login
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
#endregion
        #region TCAPIConnection with Case
        
        #endregion
        #region TCAPIConnection with Postion
        [Test]
        public void TCAPIconnection_GetPositionWithoutToken_ReturnBadStatusCode()
        {
            TCDataConnection.Token = ""; 
            var mytest = uutWithPosition.TCAPIconnection(Method.GET);
            Assert.That(mytest.StatusCode, Is.Not.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void TCAPIconnection_GetPositionValidToken_ReturnGoodStatusCode()
        {
            TCDataConnection.LogIn("test@trafficcontrol.dk", "Phantom-161");
            var mytest = uutWithPosition.TCAPIconnection(Method.GET);
            Assert.That(mytest.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        #endregion
        #region TCAPIConnection with User
        #endregion
        #region TCAPIConnection with Installation
        #endregion
    }
}
