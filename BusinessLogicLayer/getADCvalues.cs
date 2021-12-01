using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GetADCvalues
    {
        private readonly ReadADCValues adc;

        public GetADCvalues()
        {
            adc = new ReadADCValues();
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
