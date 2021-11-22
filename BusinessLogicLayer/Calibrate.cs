using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class Calibrate
    {
        public double GetAdcValues()
        {
            ReadADCValues readAdc = new ReadADCValues();

            return readAdc.ReadAdcValues();
        }
    }
}
