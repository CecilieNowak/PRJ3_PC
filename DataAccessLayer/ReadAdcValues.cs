using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ReadADCValues
    {
        private readonly Random random;
        public int LastADC { get; set; } 
        public int AdcValue { get; private set; }

        public ReadADCValues()
        {
            random = new Random();
            LastADC = 0;
            AdcValue = 0;
        }

        public int ReadAdcValues()
        {
            if (AdcValue <= LastADC)
            {
                AdcValue = random.Next(LastADC, 1000);
            }
            
            LastADC = AdcValue;

            return AdcValue;

        }


    }
}
