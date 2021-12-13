using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class SendToDatabase
    {
        private SqlCommand _command;
        private SqlDataReader _reader;

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
                @"INSERT INTO BloodPressure (cpr, systolic, diastolic, pulse, tidsstempel) OUTPUT INSERTED.Id VALUES (@CPR, @Systolic, @Diastolic, @Pulse, @Tidsstempel)";


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


        //TIL TEST AF VÆRDIER I DATABASEN
        public List<BloodPressureData> GetData(string socSecNb)
        {
            List<BloodPressureData> bp = new List<BloodPressureData>();

            byte[] sysArr = new byte[800];
            byte[] diaArr = new byte[800];
            byte[] pulseArr = new byte[400];
            double[] sys = new double[10000];
            double[] dia = new double[10000];
            int[] puls = new int[10000];
            SqlDataReader rdr;
            string selectString = "Select * from BloodPressure where Id=(SELECT MAX(Id) from BloodPressure where CPR='" + socSecNb + "')";

            using (_command = new SqlCommand(selectString, _Connection))
            {
                rdr = _command.ExecuteReader();
                if (rdr.Read())
                {
                    sysArr = (byte[])rdr["Systolic"];
                    diaArr = (byte[])rdr["Diastolic"];
                    pulseArr = (byte[])rdr["Pulse"];
                }

                for (int i = 0, j = 0; i < sysArr.Length; i += 8, j++)
                {
                    sys[j] = BitConverter.ToDouble(sysArr, i);
                    dia[j] = BitConverter.ToDouble(diaArr, i);
                    //puls[j] = BitConverter.ToInt32(pulseArr, i);
                }

                for (int i = 0, j = 0; i < pulseArr.Length; i += 8, j++)
                {
                    puls[j] = BitConverter.ToInt32(pulseArr, i);
                }

                for (int i = 0; i < sys.Length; i++)
                {
                    bp.Add(new BloodPressureData(sys[i], dia[i], puls[i]));
                }
            }
            _Connection.Close();
            return bp;
        }
    }
}

