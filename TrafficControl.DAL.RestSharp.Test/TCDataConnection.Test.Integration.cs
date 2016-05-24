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

    [TestFixture]
    public class TCDataConnectionTests
    {
        private TCDataConnection uut { get; set; }
        private TCDataConnection uutWithPosition { get; set; }

        [SetUp]
        public void Init()
        {
            uut = new TCDataConnection() {};
            uutWithPosition = new TCDataConnection() { ApiDirectory = "api/Position/"};
            TCDataConnection.ApiUrl = @"https://test.trafficcontrol.dk/";
            var fakerequest = Substitute.For<IRestRequest>();

        }

        [Test]
        public void TCDataConnection_AfterInitWithoutSettingApiDirectory_IsEmpty()
        {
            Assert.That(uut.ApiDirectory,Is.Empty);
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

            var mytest = TCDataConnection.LogIn("test@trafficcontrol.dk", "Phantom-161");
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
            TCDataConnection.LogIn("test@trafficcontrol.dk", "Phantom-161");
            var mytest = uutWithPosition.TCAPIconnection(Method.GET);
            Assert.That(mytest.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
