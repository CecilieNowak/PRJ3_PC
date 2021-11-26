using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReadADCValues
    {
        private Random random;
        public int lastADC { get; set; } 
        public int adcValue { get; private set; }

        public ReadADCValues()
        {
            random = new Random();
            lastADC = 0;
            adcValue = 0;
        }

        public int ReadAdcValues()
        {
            if (adcValue <= lastADC)
            {
                adcValue = random.Next(lastADC, 1000);
            }
            
            lastADC = adcValue;

            return adcValue;

        }


    }
}
