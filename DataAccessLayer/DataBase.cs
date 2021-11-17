using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.SqlClient;
using DTO_BloodPressureData;
using Microsoft.Data.SqlClient;
using System.IO;

namespace DataAccessLayer
{
    public class DataBase : IData
    {
        private FileStream input;
        private StreamReader reader;

        public bool IsUserRegistered(string username, string password)
        {
            bool result = false;


            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);


            string inputRecord;
            string[] inputFields;


            while ((inputRecord = reader.ReadLine()) != null)
            {

                inputFields = inputRecord.Split(';');


                if (inputFields[0] == username && inputFields[1] == password)
                {
                    result = true;

                    break;
                }
            }

            reader.Close();
            return result;
        }

        /*
        private SqlConnection _connection;
        private SqlDataReader _reader;
        private SqlCommand _command;
        private const String DBlogin = "F21ST2ITS2au669338";

        public bool IsUserRegistered(String username, String password)
        {
            bool result = false;

            _connection = new SqlConnection(@"Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _command = new SqlCommand("select * from UsersRegistered where Username ='" + username + "'", _connection);
            _connection.Open();                             
           _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                if (_reader["Username"].ToString() == username && _reader["Keyword"].ToString() == password)        
                {
                    result = true;                           
                    break;
                }
            }
            _connection.Close();                            
            return result;
        }
        */


    }




}
