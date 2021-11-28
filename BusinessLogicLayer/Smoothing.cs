using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;



namespace BusinessLogicLayer
{
    class Smoothing
    {
        private readonly List<BloodPressureData> localDTOList;
        private readonly List<BloodPressureData> returnList;
        

        public Smoothing()
        {
            localDTOList = new List<BloodPressureData>();
            returnList = new List<BloodPressureData>();
        }

        public BloodPressureData smoothGraph(List<BloodPressureData> bp)
        {

            double sum = 0;

            foreach (var dto in bp)
            {
                sum += dto.Værdi;
            }

            double average = sum / 10;

            BloodPressureData newBP = new BloodPressureData
            {
                Værdi = Convert.ToInt32(average)
            };
        
                return newBP;



        }
    }
}
