using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    public class ReadBloodPressureData
    {
        private FileStream input;
        private StreamReader reader;

        public List<BloodPressureData> ReadFromFile()
        {
            List<BloodPressureData> bpList = new List<BloodPressureData>();

            input = new FileStream("BloodPressureData.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            string inputRecord;
            string[] inputFields;

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                double systolic = Convert.ToDouble(inputFields[0]);
                double diastolic = Convert.ToDouble(inputFields[1]);
                int pulse = Convert.ToInt16(inputFields[2]);

                bpList.Add(new BloodPressureData(systolic, diastolic, pulse));

            }
            reader.Close();

            return bpList;
        }

        public double[] Systolic()
        {
            ReadBloodPressureData readFile = new ReadBloodPressureData();
            List<double> systolicValues = new List<double>();
            double[] systolicArr = new double[100];

            foreach (var systolic in readFile.ReadFromFile())
            {
                systolicValues.Add(systolic.Systolic);
            }

            for (int i = 0; i < systolicValues.Count; i++)
            {
                systolicArr[i] = systolicValues[i];
                Console.WriteLine(systolicArr[i]);
            }
            return systolicArr;
        }


        public double[] Diastolic()
        {
            ReadBloodPressureData readFile = new ReadBloodPressureData();
            List<double> diastolicValues = new List<double>();
            double[] diastolicArr = new double[100];

            foreach (var diastolic in readFile.ReadFromFile())
            {
                diastolicValues.Add(diastolic.Diastolic);

            }

            for (int i = 0; i < diastolicValues.Count; i++)
            {
                diastolicArr[i] = diastolicValues[i];
                Console.WriteLine(diastolicArr[i]);
            }
            return diastolicArr;
        }

        public int[] Pulse()
        {
            ReadBloodPressureData readFile = new ReadBloodPressureData();
            List<int> pulseValues = new List<int>();
            int[] pulseArr = new int[100];

            foreach (var pulse in readFile.ReadFromFile())
            {
                pulseValues.Add(pulse.Pulse);
            }

            for (int i = 0; i < pulseValues.Count; i++)
            {
                pulseArr[i] = pulseValues[i];
                Console.WriteLine(pulseArr[i]);
            }
            return pulseArr;
        }
    }
}
