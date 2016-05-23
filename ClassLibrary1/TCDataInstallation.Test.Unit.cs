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
                uut.LIB.TCAPIconnection(Method.GET).ReceivedCalls();
                uut.Get();
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
            //[Test]
            //public void Get_APIReturnsNothing_GetExpectedListOfInstallations()
            //{
            //    var jsonExpectedResult = JsonConvert.SerializeObject(new Installation[2] { new Installation() { Id = 1, Latitude = 56.43372, Longtitude = 10.05303 }, new Installation() { Id = 2, Latitude = 56.46389, Longtitude = 9.988638 } });
            //    uut.LIB.TCAPIconnection(Method.GET).StatusCode.Returns(HttpStatusCode.OK);
            //    uut.LIB.TCAPIconnection(Method.GET).Content.Returns(jsonExpectedResult);
            //    var jsonResult = JsonConvert.SerializeObject(uut.Get());
            //    Assert.AreEqual(jsonResult, jsonExpectedResult);
            //}

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
