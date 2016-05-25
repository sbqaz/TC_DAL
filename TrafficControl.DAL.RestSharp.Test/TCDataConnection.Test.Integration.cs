using System;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using TrafficControl.DAL.RestSharp;

namespace DAL.Test.Unit
{

    public class tokenTestDTO
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }
    /// <summary>
    /// test om TCDataConnection op mod en API, intet mocked. (ikke unit test)
    /// </summary>
    [TestFixture]
    public class TCDataConnectionTests
    {
        private string _username = "test@trafficcontrol.dk";
        private string _password = "Phantom-161";
        private TCDataConnection uut { get; set; }
        private TCDataConnection uutWithPosition { get; set; }

        [SetUp]
        public void Init()
        {
            uut = new TCDataConnection() {};
            uutWithPosition = new TCDataConnection() { ApiDirectory = "api/Position/"};
            var fakerequest = Substitute.For<IRestRequest>();
            _username = "";
            _password = "";

        }

        [Test]
        public void TCDataConnection_AfterInitWithoutSettingApiDirectory_IsEmpty()
        {
            Assert.That(uut.ApiDirectory,Is.Empty);
        }
        [Test]
        public void Login_WithValidLogin_TokenNotEmpty()
        {
            TCDataConnection.LogIn(_username, _password);
            Assert.That(TCDataConnection.Token, Is.Not.Empty);
        }
        [Test]
        public void Login_WithValidLogin_ReturnTrue()
        {
            var x = TCDataConnection.LogIn(_username, _password);
            Assert.That(x, Is.True);
        }
        [Test]
        public void Login_WithInValidLogin_ReturnsFalse()
        {
            var mytest = TCDataConnection.LogIn("test", "tester");
            Assert.That(mytest, Is.EqualTo(false));
        }
        [Test]
        public void Login_WithInValidLogin_TokenEmpty()
        {
            TCDataConnection.LogIn("test", "tester");
            Assert.That(TCDataConnection.Token, Is.Empty);
        }
        [Test]
        public void TCDataConnection_WithValidLogin_ReturnsTrue()
        {
            uut.TCAPIconnection(Method.GET);
        }
        [Test]
        public void Login_WithValidLogin_ReturnsTrue()
        {

            var mytest = TCDataConnection.LogIn(_username, _password);
            Assert.That(mytest, Is.EqualTo(true));
        }




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
            TCDataConnection.LogIn(_username, _password);
            var mytest = uutWithPosition.TCAPIconnection(Method.GET);
            Assert.That(mytest.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
