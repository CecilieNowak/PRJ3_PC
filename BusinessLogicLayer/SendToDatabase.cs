using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

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

        public void SendData()
        {
            string cpr = "123456-7890";
            int systolic = 120;
            int diastolic = 90;
            int pulse = 70;
            //DateTime dateTime = DateTime.Now;

            string insertParameters =
                @"INSERT INTO BP_TEST (cpr, systolic, diastolic, pulse) VALUES (@CPR, @Systolic, @Diastolic, @Pulse)";


            using (_command = new SqlCommand(insertParameters, _Connection))
            {
                _command.Parameters.AddWithValue("@CPR", cpr);
                _command.Parameters.AddWithValue("@Systolic", systolic);
                _command.Parameters.AddWithValue("@Diastolic", diastolic);
                _command.Parameters.AddWithValue("@Pulse", pulse);
                //_command.Parameters.AddWithValue("@Tidsstempel", dateTime);

                _command.ExecuteNonQuery();
            }

            _Connection.Close();

        }
    }
}
