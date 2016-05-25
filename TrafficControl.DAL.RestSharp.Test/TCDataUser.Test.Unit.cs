using NSubstitute;
using NUnit.Framework;
using TrafficControl.DAL.RestSharp;

namespace DAL.Test.Unit
{
    [TestFixture]
    public class TCDataUserTests
    {
        private TCDataUser uut;

        [SetUp]
        public void Init()
        {
            uut = new TCDataUser() { LIB = Substitute.For<ITCDataConnection>() };
        }
    }
}
