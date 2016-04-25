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

        public Case GetCase(int caseId)
        {
            return null;
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


        ICollection<Installation> ITCApi.Installations()
        {
            return null;
        }

        public Installation GetInstallation(int id)
        {
            return null;
        }

        public bool DeleteCase(int id)
        {
            return true;
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
