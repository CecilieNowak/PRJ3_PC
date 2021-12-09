using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;



namespace BusinessLogicLayer
{
    public class Smoothing
    {
        //private readonly List<BloodPressureData> localDTOList;
        //private readonly List<BloodPressureData> returnList;
        

        public Smoothing()
        {
            //localDTOList = new List<BloodPressureData>();
            //returnList = new List<BloodPressureData>();
        }

        public BloodPressureData smoothGraph(List<BloodPressureData> bp)
        {

            double sum = 0;
            double batterySum = 0;

            foreach (var dto in bp)
            {
                sum += dto.Værdi;           //SKAL være værdi!!
                batterySum += dto.battery;
            }

            double average = sum / bp.Count;
            double avgerageBattery = batterySum / bp.Count;
            BloodPressureData newBP = new BloodPressureData();

            if (!double.IsNaN(average))
            {

                
                    newBP.Værdi = Convert.ToInt32(average); //SKAL være værdi!!
                    newBP.battery = Convert.ToInt32(avgerageBattery);

            }

            return newBP;



        }
    }
}
