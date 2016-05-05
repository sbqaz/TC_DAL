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

        public bool CreateUser(string email, string password, string confirmedpassword, string firstname, string lastname, int roles,
            string number)
        {
            return true;
        }

        public bool CreateUser(User usr)
        {
            return true;
        }

        public bool ChangePassword(string oPassword, string nPassword, string cPassword)
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

        public bool UpdateUser(string email, string password, string name, bool smsNotification, bool emailnotifikation)
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

        public ICollection<Case> GetMyCases()
        {
            var retval = new List<Case>();

            retval.Add(new Case()
            {
                Id = 1,
                Status = CaseStatus.Created,
                Worker = "Test1"
            });

            retval.Add(new Case()
            {
                Id = 2,
                Status = CaseStatus.Started,
                Worker = "Test2"
            });

            retval.Add(new Case()
            {
                Id = 3,
                Status = CaseStatus.Done,
                Worker = "Test3"
            });

            return retval;
        }

        public Case GetCase()
        {
            throw new NotImplementedException();
        }

        public Case GetCase(int caseId)
        {
            return null;
        }

        public bool CreateCase(int installtionId, ObserverSelection observer, string errorDescription)
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
            var retval = new List<Installation>();
            retval.Add(new Installation()
            {
                Address = "Adresse Et",
                Id = 1,
                Name = "Navn Et",
                Position = new Position()
                {
                    Id = 1, 
                    Latitude = 56.460178,
                    Longtitude = 10.043286
                },
                QRKode = "What?",
                Status = 0
            });

            retval.Add(new Installation()
            {
                Address = "Adresse To",
                Id = 2,
                Name = "Navn To",
                Position = new Position()
                {
                    Id = 2,
                    Latitude = 56.459859,
                    Longtitude = 10.030006
                },
                QRKode = "What??",
                Status = 1
            });

            retval.Add(new Installation()
            {
                Address = "Adresse Tre",
                Id = 3,
                Name = "Navn Tre",
                Position = new Position()
                {
                    Id = 3,
                    Latitude = 56.463867,
                    Longtitude = 10.032424
                },
                QRKode = "What???",
                Status = 2
            });

            return retval;
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
