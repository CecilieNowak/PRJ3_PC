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
         return adc.ReadAdcValues();
        }
    }
}
