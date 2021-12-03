using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using DataAccessLayer;



namespace BusinessLogicLayer
{
    public class Filter : AbstractBloodPressureData, IBloodPressureObserver
    {

        //Klassen er både en observer og et subject
        private BloodPressureSubject _bp;
        private Smoothing smooth;
        private BloodPressureData lokalBp;
        
        

        public Filter(BloodPressureSubject bp)
        {
            _bp = bp;
            bp.Add(this);
            smooth = new Smoothing();
            
        }


        public void Update() //metoden skal retunere en DTO med gennemsnit over 10 første samples, som displayObserveren skal opdatere guien med
        {
            lokalBp = smooth.smoothGraph(_bp.GetNewestDTO());


            Notify();


        }


        public BloodPressureData getSmoothDTO()
        {
            return lokalBp;
        }
    }
}
