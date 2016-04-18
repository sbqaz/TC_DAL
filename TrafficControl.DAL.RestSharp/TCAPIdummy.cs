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

        public bool CreateUser(string email, string passWord, string name, int privileges, string number)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(string email, string passWord, string name, int privileges)
        {
            return true; 
        }

        public bool UpdateUser(string email, string passWord, string name, int privileges, int id)
        {
            throw new NotImplementedException();
        }

        public bool deleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string Opassword, string NPassword)
        {
            throw new NotImplementedException();
        }

        public ICollection<Case> GetCases()
        {
            throw new NotImplementedException();
        }

        public Case GetCase(int caseId)
        {
            throw new NotImplementedException();
        }

        public bool CreateCase(int Id, int InstalltionId, string worker, DateTime startTime, int observer, string errorDescription,
            string repair)
        {
            throw new NotImplementedException();
        }

        public bool deleteCase(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<Installation> ITCApi.Installations()
        {
            throw new NotImplementedException();
        }

        public Installation GetInstallation(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCase(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Position> GetPositions()
        {
            throw new NotImplementedException();
        }

        public Position GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
        }

        public ICollection<Installation> Installations
        {
            get { throw new NotImplementedException(); }
        }
    }
}
