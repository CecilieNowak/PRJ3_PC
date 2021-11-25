using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class getADCvalues
    {
        private ReadADCValues adc;
        public getADCvalues()
        {
            adc = new ReadADCValues();
        }
        
        public double getADCvaluesFromDataLayer()
        {
         return adc.ReadAdcValues();
        }
    }
}
