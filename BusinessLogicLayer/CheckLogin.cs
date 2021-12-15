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
        private ReadRegisteredUsers _regUsers;

        public CheckLogin()
        {
            _regUsers = new ReadRegisteredUsers();
        }

        public bool LoginCheck(String socSecNb, String pw)
        {
            bool user = _regUsers.IsUserRegistered(socSecNb, pw);

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
