using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using System.IO;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CheckLogin
    {
        private readonly IData _dataObject;

        public CheckLogin()
        {
            _dataObject = new DataBase();
        }

        public bool Login(String username, String password)
        {
            bool user = _dataObject.IsUserRegistered(username, password);

            if (user == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
