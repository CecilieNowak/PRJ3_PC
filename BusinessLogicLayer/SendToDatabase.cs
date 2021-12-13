using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows;
using DTO_BloodPressureData;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SendToDatabase
    {
        private DataBaseConnection _database;

        public SendToDatabase()
        {
            _database = new DataBaseConnection();
        }

        public void SendData(string socSecNb)
        {
            _database.SendToData(socSecNb);

        }
    }
}

