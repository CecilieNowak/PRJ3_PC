using System;

namespace DTO_BloodPressureData
{
    public class DTO_BloodPressureData
    {
        public double Systolic { get; private set; }
        public double Diastolic { get; private set; }
        public int Pulse { get; private set; }

        public DTO_BloodPressureData()
        {
            Console.WriteLine("Hej");
        }
    }
}
