using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BloodPressureSubject : AbstractBloodPressureData
    {
        private List<DTO_UDP> dtoList;
        private UDPListener udp;
        

        public BloodPressureSubject()
        {
            dtoList = new List<DTO_UDP>();
        }

        public void newDataRecieved(DTO_UDP bp)
        {
            dtoList.Add(bp);
            
            
            Notify();

        }

        public DTO_UDP getNewestDTO()
        {
            int counter = dtoList.Count - 1;
            return dtoList[counter];
        }

    }

}
