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
        List<double> SysList = new List<double>();
        List<double> DiaList = new List<double>();

        private BloodPressureData bp;

        public CalcBP()
        {
            bp = new BloodPressureData();
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

            for (int i = 5; i <= data.Count - 5; i++)
            {
                //if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i - 2].Værdi && data[i].Værdi > data[i - 3].Værdi && data[i].Værdi > data[i - 4].Værdi && data[i].Værdi > data[i + 1].Værdi && data[i].Værdi > data[i + 2].Værdi && data[i].Værdi > data[i + 3].Værdi && data[i].Værdi > data[i + 4].Værdi)
                //{
                //    bp.Systolic = data[i].Værdi;
                //    sys.Add(data[i]);
                //}
            }
            return bp.Systolic;
        }


        public List<double> GetSys()
        {
            foreach (var item in sys)
            {
                //SysList.Add(Convert.ToDouble(item));
            }
            return SysList;
        }

        public double CalcDia(List<BloodPressureData> data)
        {
            for (int i = 5; i <= data.Count - 5; i++)
            {
                //if (data[i].Værdi < data[i - 1].Værdi && data[i].Værdi < data[i - 2].Værdi && data[i].Værdi < data[i - 3].Værdi && data[i].Værdi < data[i - 4].Værdi && data[i].Værdi < data[i + 1].Værdi && data[i].Værdi < data[i + 2].Værdi && data[i].Værdi < data[i + 3].Værdi && data[i].Værdi < data[i + 4].Værdi)
                //{
                //    bp.Diastolic = data[i].Værdi;
                //    dia.Add(data[i]);
                //}
            }
            return bp.Diastolic;
        }


        public List<double> GetDia()
        {
            foreach (var item in dia)
            {
                //DiaList.Add(Convert.ToDouble(item));
            }
            return DiaList;
        }
    }
}
