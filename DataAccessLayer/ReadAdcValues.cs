using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReadADCValues
    {
        private Random random;
        public double lastADC { get; set; } = 0;

        public double ReadAdcValues()
        {
            random = new Random();


            double adcValue = random.Next(0, 1000);
            while(adcValue < lastADC)
            {
                adcValue = random.Next(0, 1000);
            }
            lastADC = adcValue;

            return adcValue;

        }
    }
}
