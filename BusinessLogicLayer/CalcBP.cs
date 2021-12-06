using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class CalcBP
    {
        //List<int> data = new List<int> { 1, 5, 4, 3, 2, 5, 7, 8, 4, 2, 1, 4 };

        List<BloodPressureData> sys = new List<BloodPressureData>();
        List<BloodPressureData> dia = new List<BloodPressureData>();

        private BloodPressureData bp;

        public CalcBP()
        {
            bp = new BloodPressureData();
        }

        public double CalcSys(List<BloodPressureData> data)
        {
            for (int i = 1; i <= data.Count - 2; i++)
            {
                if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i + 1].Værdi)
                {
                    bp.Diastolic = data[i].Værdi;
                }
            }
            return bp.Diastolic;
        }

        public double CalcDia(List<BloodPressureData> data)
        {
            for (int i = 1; i <= data.Count - 2; i++)
            {
                if (data[i].Værdi < data[i - 1].Værdi && data[i].Værdi < data[i + 1].Værdi)
                {
                    bp.Diastolic = data[i].Værdi;
                }
            }
            return bp.Diastolic;
        }
    }
}
