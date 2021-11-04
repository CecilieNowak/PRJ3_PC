using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    public interface IData
    {
        bool IsUserRegistered(String socSecNb, String pw);
    }
}
