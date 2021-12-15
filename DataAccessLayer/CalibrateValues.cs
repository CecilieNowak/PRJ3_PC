using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    public class CalibrateValues
    {
        private FileStream input;
        private StreamReader reader;
        private string path;

        public CalibrateValues()
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
    }
}
