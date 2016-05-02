using System;
using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public class TCAPIdummy: ITCApi
    {
        public bool LogIn(string email, string encryptedPassWord)
        {
            return true; 
        }

        public bool CreateUser(User usr)
        {
            return true;
        }

<<<<<<< HEAD
        public bool ChangePassword(string oPassword, string nPassword, string cPassword)
=======
        public bool CreateUser(string email, string password, string confirmedpassword, string firstname, string lastname, int roles,
            string number)
>>>>>>> refs/remotes/origin/master
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(string email, string passWord, string name, int privileges, string number)
        {
            return true;
        }

        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            return true;
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            return true;
        }

        public bool deleteUser(int id)
        {
            return true;
        }

        public bool ChangePassword(string opassword, string nPassword)
        {
            return true;
        }

        public bool UpdateUser(User usr)
        {
            return true;
        }

        public bool UpdateUser(string email, string password, string name, bool smsnotifikation, bool emailnotifikation)
        {
            throw new NotImplementedException();
        }

        public bool ChangeName(string name)
        {
            throw new NotImplementedException();
        }

        public bool ChangeUser(User usr)
        {
            throw new NotImplementedException();
        }

        public ICollection<Case> GetCases()
        {
            return null;
        }

        public Case GetCase()
        {
            throw new NotImplementedException();
        }

        public Case GetCase(int caseId)
        {
            return null;
        }

        public bool CreateCase(int InstalltionId, int observer, string errorDescription)
        {
            throw new NotImplementedException();
        }

        public bool CreateCase(int Id, int InstalltionId, string worker, DateTime startTime, int observer, string errorDescription,
            string repair)
        {
            return true;
        }

        public bool deleteCase(int id)
        {
            return true;
        }


        public bool UpdateCase(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCase(Case myCase)
        {
            throw new NotImplementedException();
        }

        ICollection<Installation> ITCApi.GetInstallations()
        {
            return null;
        }

        public Installation GetInstallation(int id)
        {
            return null;
        }

        public bool DeleteInstallation(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInstalltion(Installation obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCase(int id)
        {
            return true;
        }

        public bool UpdateInstalltion()
        {
            throw new NotImplementedException();
        }

        public ICollection<Position> GetPositions()
        {
            return null;
        }

        public Position GetPosition(int id)
        {
            return null;
        }

        public bool DeletePosition(int id)
        {
            return true;
        }

        public bool UpdatePosition(Position position)
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            var retval = new User();
            retval.EmailNotification = true;
            retval.SMSNotification = false;
            retval.FirstName = "TestPerson";
            retval.LastName = "Hansen";
            retval.Number = "+4560221133";
            retval.Id = "1";
            return retval;
        }

        public bool UpdateUser(string email, string password, string name, int privileges, string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
