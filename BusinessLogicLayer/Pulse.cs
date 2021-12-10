using DTO_BloodPressureData;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    class Pulse
    {

        private BloodPressureData bp;

        public Pulse()
        {
            bp = new BloodPressureData();
        }

        //public double CalcPulse(List<BloodPressureData> data)
        //{
        //    //data.count / sysList.count
        //}



        //public double CalcMean(List<BloodPressureData> data)
        //{
        //    int i = 5;
        //    if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i - 2].Værdi && data[i].Værdi > data[i - 3].Værdi && data[i].Værdi > data[i - 4].Værdi && data[i].Værdi > data[i + 1].Værdi && data[i].Værdi > data[i + 2].Værdi && data[i].Værdi > data[i + 3].Værdi && data[i].Værdi > data[i + 4].Værdi)
        //    {
        //        bp.Systolic = data[i].Værdi;
        //        //sys.Add(data[i]);
        //        SysList.Add(data[i].Værdi);
        //    }

        //    return bp.Systolic;
        //}

        //public double GetMean()
        //{

        //    return SysList;
        //}



        //int DTOsBetweenEverySys;

        //public int GetNoOfDTOBetweenSys()
        //{
        //    return DTOsBetweenEverySys;
        //}


        //public int GetPulse()
        //{
        //    int pulse = 15 / DTOsBetweenEverySys * 60;         // 15 er antal DTO's pr sekund. Ganger med 60 for at få pulsslag pr min
        //    return pulse;
        //}


    }
}
