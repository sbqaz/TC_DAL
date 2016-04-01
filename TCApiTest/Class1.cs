using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TrafficControl.DAL;
namespace TCApiTest
{
    [TestFixture]
    public class Class1
    {
        private TrafficControl.DAL.ITCApi _uut;

        [SetUp]
        public void Init()
        {
            _uut = new TCApi();
        }

         [Test]
          public void Login_WithSimpleData_Succes()
          {
              Assert.That(_uut.LogIn("wb@wnb.dk", "1234"),Is.True);
          }


        [Test]
        public void createUser_WithInput_newUserCreated()
        {

            var email = "test@test.dk";
            var pass = "1234";
            var name = "test";
            var pri = 10;

            Assert.That(_uut.CreateUser(email, pass, name, pri), Is.True);
        }
        [Test]
        public void deleteUser_yay()
        {
            Assert.That(_uut.deleteUser(12),Is.True);
        }
        /*
        [Test]
        public void UpdateUser_WithnewName_newupdatedName()
        {
            var email = "test2@test.dk";
            var pass = "12345";
            var name = "test";
            var pri = 20;

            Assert.That(_uut.UpdateUser(email, pass, name,pri,10), Is.True);
        }
        */
    }
}
