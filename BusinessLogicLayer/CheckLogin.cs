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
            _dataObject = new ReadRegisteredUsers();
        }

        public bool LoginCheck(String socSecNb, String pw)
        {
            bool user = _dataObject.IsUserRegistered(socSecNb, pw);

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
