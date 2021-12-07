using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class CalcBP
    {
       

        List<BloodPressureData> sys = new List<BloodPressureData>();
        List<BloodPressureData> dia = new List<BloodPressureData>();
        private List<double> SysList;
        List<double> DiaList = new List<double>();

        private BloodPressureData bp;

        public CalcBP()
        {
            bp = new BloodPressureData();
            sys = new List<BloodPressureData>();
            SysList = new List<double>();
        }

        public double CalcSys(List<BloodPressureData> data)
        {
            //for (int i = 1; i <= data.Count - 2; i++)
            //{
            //    if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i + 1].Værdi)
            //    {
            //        bp.Diastolic = data[i].Værdi;
            //    }
            //}

            // Metode opdateret med filter



          
                int i = 5;
                if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i - 2].Værdi && data[i].Værdi > data[i - 3].Værdi && data[i].Værdi > data[i - 4].Værdi && data[i].Værdi > data[i + 1].Værdi && data[i].Værdi > data[i + 2].Værdi && data[i].Værdi > data[i + 3].Værdi && data[i].Værdi > data[i + 4].Værdi)
                {
                    bp.Systolic = data[i].Værdi;
                    sys.Add(data[i]);
                    SysList.Add(data[i].Værdi);
                }

                return bp.Systolic;
        }


        public List<double> GetSys()
        {
            
            return SysList;
        }

        public double CalcDia(List<BloodPressureData> data)
        {
            for (int i = 5; i <= data.Count - 5; i++)
            {
                if (data[i].Værdi < data[i - 1].Værdi && data[i].Værdi < data[i - 2].Værdi && data[i].Værdi < data[i - 3].Værdi && data[i].Værdi < data[i - 4].Værdi && data[i].Værdi < data[i + 1].Værdi && data[i].Værdi < data[i + 2].Værdi && data[i].Værdi < data[i + 3].Værdi && data[i].Værdi < data[i + 4].Værdi)
                {
                    bp.Diastolic = data[i].Værdi;
                    dia.Add(data[i]);
                }
            }
            return bp.Diastolic;
        }


        public List<double> GetDia()
        {
            foreach (var item in dia)
            {
                DiaList.Add(item.Diastolic);
            }
            return DiaList;
        }
    }
}
