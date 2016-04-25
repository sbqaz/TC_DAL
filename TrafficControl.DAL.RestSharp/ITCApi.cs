﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using TrafficControl.DAL.RestSharp.Types;
namespace TrafficControl.DAL.RestSharp
{
    public interface ITCApi
    {
#region Account
        bool LogIn(string email, string encryptedPassWord);
        bool CreateUser(User usr);
        bool CreateUser(string email, string password, string name, int privileges, string number);
        
        bool ChangePassword(string oPassword, string nPassword);
        bool UpdateUser(User usr);
        #endregion
#region Cases
        ICollection<Case> GetCases();
        Case GetCase(int caseId);
        bool CreateCase(int Id, int InstalltionId, string worker, DateTime startTime, int observer,
            string errorDescription, string repair);
        bool deleteCase(int id);
        #endregion

#region Installations
        ICollection<Installation> Installations();
        Installation GetInstallation(int id);
        bool DeleteCase(int id);
        #endregion

#region Position
        ICollection<Position> GetPositions();
        Position GetPosition(int id);
        bool DeletePosition(int id);
        #endregion

#region User

        User GetUser();
        bool UpdateUser(string email, string password, string name, int privileges, string id);
        bool DeleteUser(int id);

        #endregion

    }
}