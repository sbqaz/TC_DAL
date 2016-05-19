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
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Randersvej - Aarhusvej",
                    Position = new Position()
                    {
                        Id = 1,
                        Latitude = 56.460178,
                        Longtitude = 10.043286
                    },
                    Status = 0
                },
                Status = CaseStatus.Created,
                Worker = "Jens Hansen",
                Time = new DateTime(2016, 5, 1, 1, 42, 16),
            });

            return retval;
        }

        public Case GetCase()
        {
            throw new NotImplementedException();
        }

        public Case GetCase(long caseId)
        {
            return new Case()
            {
                Id = 1,
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Aarhusvej - Randersvej",
                    Position = new Position()
                    {
                        Id = 1,
                        Latitude = 56.460178,
                        Longtitude = 10.043286
                    },
                    Status = 1
                },
                Worker = "TestPerson Hansen",
                Status = CaseStatus.Created,
                Observer = ObserverSelection.Police,
                ErrorDescription = "Der er en fejl et sted...",
                Time = new DateTime(2016, 5, 15, 17, 41, 55),
                MadeRepair = "Intet lavet",
                UserComment = "Ingen kommentarer endnu"
            };
        }

        public bool ClaimCase(long id)
        {
            return true;
        }

        public bool CreateCase(long installtionId, ObserverSelection observer, string errorDescription)
        {
            return true;
        }

        public bool CreateCase(long Id, long InstalltionId, string worker, DateTime startTime, int observer, string errorDescription,
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
            return true;
        }

        public bool UpdateCase(Case myCase)
        {
            return true;
        }

        public ICollection<Case> GetCases()
        {
            var retval = new List<Case>();
            
            retval.Add(new Case()
            {
                Id = 11,
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Randersvej - Aarhusvej",
                    Position = new Position()
                    {
                        Id = 1,
                        Latitude = 56.460178,
                        Longtitude = 10.043286
                    },
                    Status = 0
                },
                Status = CaseStatus.Created,
                Worker = "Jens Hansen",
                Time = new DateTime(2016, 5, 9, 9, 42, 52),
            });

            retval.Add(new Case()
            {
                Id = 22,
                Installation = new Installation()
                {
                    Id = 2,
                    Name = "Nørrebro - Vestergade",
                    Position = new Position()
                    {
                        Id = 2,
                        Latitude = 56.459859,
                        Longtitude = 10.030006
                    },
                    Status = 1
                },
                Status = CaseStatus.Started,
                Worker = "Per Pedersen",
                Time = new DateTime(2016, 1, 22, 23, 58, 52),
            });

            retval.Add(new Case()
            {
                Id = 33,
                Installation = new Installation()
                {
                    Id = 3,
                    Name = "Finlandsgade - Randersvej",
                    Position = new Position()
                    {
                        Id = 3,
                        Latitude = 56.463867,
                        Longtitude = 10.032424
                    },
                    Status = 2
                },
                Status = CaseStatus.Done,
                Worker = "Hans Jensen",
                Time = new DateTime(2016, 5, 8, 15, 2, 22),
            });

            return retval;
        }

        ICollection<Installation> ITCApi.GetInstallations()
        {
            var retval = new List<Installation>();
            retval.Add(new Installation()
            {
                Id = 1,
                Name = "Randersvej - Aarhusvej",
                Position = new Position()
                {
                    Id = 1, 
                    Latitude = 56.460178,
                    Longtitude = 10.043286
                },
                Status = 0
            });

            retval.Add(new Installation()
            {
                Id = 2,
                Name = "Nørrebro - Vestergade",
                Position = new Position()
                {
                    Id = 2,
                    Latitude = 56.459859,
                    Longtitude = 10.030006
                },
                Status = 1
            });

            retval.Add(new Installation()
            {
                Id = 3,
                Name = "Finlandsgade - Randersvej",
                Position = new Position()
                {
                    Id = 3,
                    Latitude = 56.463867,
                    Longtitude = 10.032424
                },
                Status = 2
            });

            return retval;
        }

        public Installation GetInstallation(long id)
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

        public Position GetPosition(long id)
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
