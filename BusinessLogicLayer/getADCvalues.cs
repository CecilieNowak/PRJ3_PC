using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class getADCvalues
    {
        public double getADCvaluesFromDataLayer()
        {
            ReadADCValues adc = new ReadADCValues();
            return adc.ReadAdcValues();
        }
    }
}
