using System;

namespace DTO_BloodPressureData
{
    public class DTO_BloodpressureData
    {
        public double Systolic { get; private set; }
        public double Diastolic { get; private set; }
        public int Pulse { get; private set; }

        public DTO_BloodpressureData()
        {
        }
    }
}
