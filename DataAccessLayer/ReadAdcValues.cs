using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReadADCValues
    {
        private Random random;

        public double ReadAdcValues()
        {
            random = new Random();

            double adcValue = random.Next(10, 100);

            return adcValue;

        }
    }
}
