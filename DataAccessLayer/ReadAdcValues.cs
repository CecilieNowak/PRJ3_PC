using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReadADCValues
    {
        private Random random;
        public double LastADC { get; set; } = 0;

        public double ReadAdcValues()
        {
            random = new Random();

            double adcValue = random.Next(0, 1000);
            while (adcValue < LastADC)
            {
                adcValue = random.Next(0, 1000);
            }
            LastADC = adcValue;

            return adcValue;

        }


    }
}
