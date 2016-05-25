using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using RestSharp;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace DAL.Test.Unit
{
    /// <summary>
    /// En Unit Test for TCDataPosition DataConnection substitued out.
    /// </summary>
    [TestFixture]
    public class TCDataPositionTests
    {
        private TCDataPosition uut { get; set; }
        private Position TestObj { get; set; }
        private TCDataConnection FakeConnection { get; set; }
        [SetUp]
        public void Init()
        {
            uut = new TCDataPosition() {LIB = Substitute.For<ITCDataConnection>()};
            TestObj = Substitute.For<Position>();
            FakeConnection = Substitute.For<TCDataConnection>();
        }

        [Test]
        public void Get_CallingGet_APIClientCallsTheCorrectFunc()
        {
            uut.LIB.TCAPIconnection(Method.GET).ReceivedCalls();
            uut.Get();
        }
        [Test]
        public void Get_APIReturnsNothing_GetEmptyPosition()
        {
            uut.LIB.TCAPIconnection(Method.GET).Content.Returns("[]");
            var jsonResult = JsonConvert.SerializeObject(uut.Get());
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position[0]);
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }
        [Test]
        public void GetWithID_APIReturnsNothing_GetEmptyPosition()
        {
            uut.LIB.TCAPIconnection(Method.GET,2).Content.Returns("");
            var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position());
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }
        [Test]
        public void Get_WithId_GetExpectedPosition()

        {
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position() { Id = 1, Latitude = 56.43372, Longtitude = 10.05303 });
            uut.LIB.TCAPIconnection(Method.GET,Arg.Any<long>()).StatusCode.Returns(HttpStatusCode.OK);
            uut.LIB.TCAPIconnection(Method.GET,Arg.Any<long>()).Content.Returns(jsonExpectedResult);
            var jsonResult = JsonConvert.SerializeObject(uut.Get(1));
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }
        [Test]
        public void Get_APIRespondedNotOkayStatusCode_GetExpectedPosition()

        {
            var AjsonResult = JsonConvert.SerializeObject(new Position() { Id = 1, Latitude = 56.43372, Longtitude = 10.05303 });
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position());
            uut.LIB.TCAPIconnection(Method.GET, Arg.Any<long>()).StatusCode.Returns(HttpStatusCode.GatewayTimeout);
            uut.LIB.TCAPIconnection(Method.GET, Arg.Any<long>()).Content.Returns(AjsonResult);
            var jsonResult = JsonConvert.SerializeObject(uut.Get(1));
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }
        [Test]
        public void Get_APIReturnsNothing_GetExpectedListOfPositions()
        {
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position[2] { new Position() { Id = 1, Latitude = 56.43372, Longtitude = 10.05303 }, new Position() { Id = 2, Latitude = 56.46389, Longtitude = 9.988638 } });
            uut.LIB.TCAPIconnection(Method.GET).StatusCode.Returns(HttpStatusCode.OK);
            uut.LIB.TCAPIconnection(Method.GET).Content.Returns(jsonExpectedResult);
            var jsonResult = JsonConvert.SerializeObject(uut.Get());
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }

        [Test]
        public void GetWithID_APIReturnsNothing_GetPosition()
        {
            uut.LIB.TCAPIconnection(Method.GET, 2).Content.Returns("");
            var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
            var jsonExpectedResult = JsonConvert.SerializeObject(new Position());
            Assert.AreEqual(jsonResult, jsonExpectedResult);
        }
    }
}
