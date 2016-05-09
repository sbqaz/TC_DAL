using System;
using NSubstitute;
using NUnit.Framework;
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
            uut = new TCDataPosition();
            TestObj = Substitute.For<Position>();
            FakeConnection = Substitute.For<TCDataConnection>();
        }

        [Test]
        public void Get_CallingPost_APIClientCallsTheCorrectFunc()
        {
            
        }
    }
}
