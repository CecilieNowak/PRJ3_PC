using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using DataAccessLayer;



namespace BusinessLogicLayer
{
    public class Filter : AbstractBloodPressureData, IBloodPressureObserver
    {
        private BloodPressureSubject _bp;
        private Smoothing smooth;
        

        public Filter(BloodPressureSubject bp)
        {
            _bp = bp;
            bp.Add(this);
            smooth = new Smoothing();
        }


        public void Update() //metoden skal retunere en DTO med gennemsnit over 10 første samples, som displayObserveren skal opdatere guien med
        {
            //display();
            Notify();


        }

        public BloodPressureData display()
        {
            List<BloodPressureData> dto = _bp.GetNewestDTO();
            return smooth.smoothGraph(dto);
        }
    }
}
