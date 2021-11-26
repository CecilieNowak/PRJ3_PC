using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BloodPressureSubject : AbstractBloodPressureData
    {
        private readonly List<BloodPressureData> dtoList;
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
        }

        public void NewDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);
            
            
            Notify();

        }

        public BloodPressureData GetNewestDTO()
        {
            int counter = dtoList.Count - 1;
            return dtoList[counter];
        }

    }

}
