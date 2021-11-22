using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BloodPressureSubject : AbstractBloodPressureData
    {
        private List<BloodPressureData> dtoList;
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
        }

        public void newDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);
            
            
            Notify();

        }

        public BloodPressureData getNewestDTO()
        {
            int counter = dtoList.Count - 1;
            return dtoList[counter];
        }

    }

}
