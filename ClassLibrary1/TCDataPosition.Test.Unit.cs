using System;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace DAL.Test.Unit
{
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
        public void Get_CallingPost_APIClientCallsTheCorrectFunc()
        {
            uut.LIB.TCAPIconnection(Method.GET).ReceivedWithAnyArgs();
            uut.Post(new Position() {Id = 0, Latitude = 0, Longtitude = 0});
        }
        [Test]
        public void Get_CallingPost_APIClientReturns()
        {
            uut.LIB.TCAPIconnection(Method.GET).Content.Returns("");
        }

    }
}
