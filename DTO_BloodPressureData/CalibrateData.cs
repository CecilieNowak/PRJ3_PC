using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_BloodPressureData
{
    public class CalibrateData
    {
        public double A { get; set; } = 1;
        public double B { get; set; } = 0;

        public CalibrateData()
        { }

        public CalibrateData(double a, double b)
        {
            A = a;
            B = b;
        }

    }
}
