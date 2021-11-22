using System;




namespace DTO_BloodPressureData
{
    public class BloodPressureData 
    {
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public int Pulse { get; set; }

        public BloodPressureData()
        {

        }

        public BloodPressureData(double systolic, double diastolic, int pulse)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Pulse = pulse;
        }
    }
}
