using System;
using System.Collections.Generic;
using System.Linq;
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
        private CalcBP calcBp;
        private List<BloodPressureData> lokalList;
        public double A { get; set; }
        public double B { get; set; }



        public Filter(BloodPressureSubject bp)
        {
            _bp = bp;
            bp.Add(this);

            smooth = new Smoothing();
            calcBp = new CalcBP();

            lokalList = new List<BloodPressureData>();

        }


        public void Update() //metoden skal retunere en DTO med gennemsnit over 10 første samples, som displayObserveren skal opdatere guien med
        {
            lokalList = _bp.GetNewestDTO();                         //Henter seneste 10 DTO'er
            lokalBp = smooth.smoothGraph(lokalList);                //Gennemsnit af DTO'er 

            lokalBp.Værdi = lokalBp.Værdi;
            //lokalBp = _bp.dtoList.Last();

            //Kalibrering
            
            lokalBp.Systolic = calcBp.CalcSys(lokalList);
            lokalBp.Diastolic = calcBp.CalcDia(lokalList); 
            //Log data

            Notify();


        }


        public BloodPressureData getDTOSample()
        {
            return lokalBp;
        }
    }
}
