using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GetADCvalues
    {
        private readonly ReadADCValues adc;
        private BloodPressureSubject _bloodPressureSubject;

        public GetADCvalues(BloodPressureSubject bps)
        {
            _bloodPressureSubject = bps;
        }
        
        public double GetADCvaluesFromDataLayer()
        {
            double a = adc.ReadAdcValues();
            double adcValue = a;   

            return adcValue;

            //return adc.ReadAdcValues();
        }
    }
}
