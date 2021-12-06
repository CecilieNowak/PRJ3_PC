using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.SqlClient;
using DTO_BloodPressureData;
using Microsoft.Data.SqlClient;
using System.IO;

namespace DataAccessLayer
{
    public class ReadRegisteredUsers : IData
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
    }
}
