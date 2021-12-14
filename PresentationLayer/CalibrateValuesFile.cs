using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DTO_BloodPressureData;
using MathNet.Numerics;

namespace PresentationLayer
{
    class CalibrateValuesFile
    {
        private FileStream input;
        private StreamReader reader;
        private string path;

        public CalibrateValuesFile()
        {
            path = @"CalibrateData.txt";
        }

        public void LogFile(CalibrateData calibrateData)
        {
            List<CalibrateData> DTO = new List<CalibrateData>();
            
            DTO.Add(new CalibrateData(calibrateData.A, calibrateData.B));

            if (File.Exists(path))
            {
                using StreamWriter sw = File.AppendText(path);
                foreach (CalibrateData dtoData in DTO)
                {
                    sw.WriteLine(dtoData.A + ";" + dtoData.B);
                }

                sw.Close();
            }
        }

        public CalibrateData ReadFromFile()
        {
            CalibrateData calibrateDTO = new CalibrateData();

            input = new FileStream("CalibrateData.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            string inputRecord;
            string[] inputFields;

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                double A = Convert.ToDouble(inputFields[0]);
                double B = Convert.ToDouble(inputFields[1]);

                calibrateDTO = new CalibrateData(A, B);

            }
            reader.Close();

            return calibrateDTO;
        }

        //public double CalA()
        //{
        //    CalibrateValuesFile readFile = new CalibrateValuesFile();
        //    List<double> AValue = new List<double>();

        //    double A = AValue[0];

        //    foreach (var value in readFile.ReadFromFile())
        //    {
        //        AValue = value.A;
        //    }

        //    for (int i = 0; i < AValue.Count; i++)
        //    {
        //        aArr[i] = AValue[i];
        //    }
        //    return systolicArr;
        //}


        //public double[] Diastolic()
        //{
        //    ReadBloodPressureData readFile = new ReadBloodPressureData();
        //    List<double> diastolicValues = new List<double>();
        //    double[] diastolicArr = new double[5000];

        //    foreach (var diastolic in readFile.ReadFromFile())
        //    {
        //        diastolicValues.Add(diastolic.Diastolic);

        //    }

        //    for (int i = 0; i < diastolicValues.Count; i++)
        //    {
        //        diastolicArr[i] = diastolicValues[i];
        //        Console.WriteLine(diastolicArr[i]);
        //    }
        //    return diastolicArr;
        //}

    }
}
