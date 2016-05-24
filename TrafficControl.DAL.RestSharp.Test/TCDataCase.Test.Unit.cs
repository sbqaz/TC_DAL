using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace DAL.Test.Unit
{
    [TestFixture]
    public class TCDataCaseTests
    {
        //private TCDataCaseTests uut = null;
        //[SetUp]
        //public void Init()
        //{
        //    uut = new TCDataCaseTests();
        //}
        //[Test]
        //public void Get_CallingGet_APIClientCallsTheCorrectFunc()
        //{
        //    uut.Get();
        //    uut.LIB.TCAPIconnection(Method.GET).ReceivedCalls();

        //}
        //[Test]
        //public void Get_APIReturnsNothing_GetEmptyInstallation()
        //{
        //    uut.LIB.TCAPIconnection(Method.GET).Content.Returns("[]");
        //    var jsonResult = JsonConvert.SerializeObject(uut.Get());
        //    var jsonExpectedResult = JsonConvert.SerializeObject(new Installation[0]);
        //    Assert.AreEqual(jsonResult, jsonExpectedResult);
        //}
        //[Test]
        //public void GetWithID_APIReturnsNothing_GetEmptyInstallation()
        //{
        //    uut.LIB.TCAPIconnection(Method.GET, 2).Content.Returns("");
        //    var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
        //    var jsonExpectedResult = JsonConvert.SerializeObject(new Installation());
        //    Assert.AreEqual(jsonResult, jsonExpectedResult);
        //}

        //[Test]
        //public void GetWithID_APIReturnsNothing_GetInstallation()
        //{
        //    uut.LIB.TCAPIconnection(Method.GET, 2).Content.Returns("");
        //    var jsonResult = JsonConvert.SerializeObject(uut.Get(2));
        //    var jsonExpectedResult = JsonConvert.SerializeObject(new Installation());
        //    Assert.AreEqual(jsonResult, jsonExpectedResult);
        //}
    }
}
