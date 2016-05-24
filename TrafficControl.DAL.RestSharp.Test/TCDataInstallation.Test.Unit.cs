using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;
    using NSubstitute;
    using NUnit.Framework;
    using RestSharp;
    using TrafficControl.DAL.RestSharp;
    using TrafficControl.DAL.RestSharp.Types;

    namespace DAL.Test.Unit
    {
        [TestFixture]
        public class TCDataInstallationTests
        {
            private TCDataInstallation uut { get; set; }
            private Installation TestObj { get; set; }
            private TCDataConnection FakeConnection { get; set; }
            [SetUp]
            public void Init()
            {
                uut = new TCDataInstallation() { LIB = Substitute.For<ITCDataConnection>() };
                TestObj = Substitute.For<Installation>();
                FakeConnection = Substitute.For<TCDataConnection>();
            }

            [Test]
            public void Get_CallingGet_APIClientCallsTheCorrectFunc()
            {
                uut.Get();
                uut.LIB.TCAPIconnection(Method.GET).ReceivedCalls();
                
            }
            [Test]
            public void Get_APIReturnsNothing_GetEmptyInstallation()
            {
                uut.LIB.TCAPIconnection(Method.GET).Content.Returns("[]");
                var jsonResult = JsonConvert.SerializeObject(uut.Get());
                var jsonExpectedResult = JsonConvert.SerializeObject(new Installation[0]);
                Assert.AreEqual(jsonResult, jsonExpectedResult);
            }
            [Test]
            public void GetWithID_APIReturnsNothing_GetEmptyInstallation()
            {
                uut.LIB.TCAPIconnection(Method.GET, 2).Content.Returns("");
                var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
                var jsonExpectedResult = JsonConvert.SerializeObject(new Installation());
                Assert.AreEqual(jsonResult, jsonExpectedResult);
            }

            [Test]
            public void GetWithID_APIReturnsNothing_GetInstallation()
            {
                uut.LIB.TCAPIconnection(Method.GET, 2).Content.Returns("");
                var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
                var jsonExpectedResult = JsonConvert.SerializeObject(new Installation());
                Assert.AreEqual(jsonResult, jsonExpectedResult);
            }

        }
    }

}
