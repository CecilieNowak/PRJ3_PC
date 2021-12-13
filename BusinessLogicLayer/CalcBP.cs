using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class CalcBP
    {


        //List<BloodPressureData> sys = new List<BloodPressureData>();
        //List<BloodPressureData> dia = new List<BloodPressureData>();
        List<double> SysList;
        List<double> DiaList;
        List<double> MeanList;
        private BloodPressureData bp;
        private BloodPressureSubject subject;
        List<BloodPressureData> sys = new List<BloodPressureData>();

        public CalcBP()
        {
            bp = new BloodPressureData();
            SysList = new List<double>();
            DiaList = new List<double>();
            MeanList = new List<double>();
            subject = new BloodPressureSubject();
            sys = new List<BloodPressureData>();
        }

        //public double CalcMean(List<BloodPressureData> data)
        //{
        //    data = subject.GetNewestDTOMean();
        //    if (SysList.Count > 1)
        //    {
        //        bp.Avg = data.Count / SysList.Count;
        //    }


        //    return bp.Avg;
        //}

        //public List<double> GetMean()
        //{
        //    return MeanList;
        //}


        public double CalcSys(List<BloodPressureData> data)
        {
            int i = 5;
            if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i - 2].Værdi && data[i].Værdi > data[i - 3].Værdi && data[i].Værdi > data[i - 4].Værdi
            && data[i].Værdi > data[i + 1].Værdi && data[i].Værdi > data[i + 2].Værdi && data[i].Værdi > data[i + 3].Værdi && data[i].Værdi > data[i + 4].Værdi)
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
            int i = 5;
            if (data[i].Værdi < data[i - 1].Værdi && data[i].Værdi < data[i - 2].Værdi && data[i].Værdi < data[i - 3].Værdi && data[i].Værdi < data[i - 4].Værdi && data[i].Værdi < data[i + 1].Værdi && data[i].Værdi < data[i + 2].Værdi && data[i].Værdi < data[i + 3].Værdi && data[i].Værdi < data[i + 4].Værdi)
            {
                bp.Diastolic = data[i].Værdi;
                DiaList.Add(data[i].Værdi);
            }
            return bp.Diastolic;
        }


        public List<double> GetDia()
        {
            return DiaList;
        }
    }
}
