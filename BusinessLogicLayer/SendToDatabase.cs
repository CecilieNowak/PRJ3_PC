﻿using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    public class SendToDatabase
    {
        private SqlCommand _command;

        private SqlConnection _Connection
        {
            get
            {
                var connection = new SqlConnection(@"Data Source=st-i4dab.uni.au.dk;Initial Catalog=F21ST2ITS2au669338;User ID=F21ST2ITS2au669338; Password=F21ST2ITS2au669338;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                return connection;
            }
        }

        public void SendData(string socSecNb)
        {
            ReadBloodPressureData readFile = new ReadBloodPressureData();
            string cpr = socSecNb;
            double[] systolic = readFile.Systolic();
            double[] diastolic = readFile.Diastolic();
            int[] pulse = readFile.Pulse();
            DateTime tidsstempel = DateTime.Now;

            string insertParameters =
                @"INSERT INTO BloodPressureMeasurement (cpr, systolic, diastolic, pulse, tidsstempel) OUTPUT INSERTED.Id VALUES (@CPR, @Systolic, @Diastolic, @Pulse, @Tidsstempel)";


            using (_command = new SqlCommand(insertParameters, _Connection))
            {
                _command.Parameters.AddWithValue("@CPR", cpr);
                _command.Parameters.AddWithValue("@Systolic", systolic.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
                _command.Parameters.AddWithValue("@Diastolic", diastolic.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
                _command.Parameters.AddWithValue("@Pulse", pulse.SelectMany(value => BitConverter.GetBytes(value)).ToArray());
                _command.Parameters.AddWithValue("@Tidsstempel", tidsstempel);

                //int id = (int) _command.ExecuteScalar();
                _command.ExecuteNonQuery();
            }

            _Connection.Close();
        }
    }
}

