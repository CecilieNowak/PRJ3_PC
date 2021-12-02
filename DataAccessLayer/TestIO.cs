using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    public class TestIO
    {
        string text;
        string text1;
      
        public void Test()
        {
            List<BloodPressureData> DTO = new List<BloodPressureData>();

            DTO.Add(new BloodPressureData(140,90,90));
            DTO.Add(new BloodPressureData(130, 95, 90));
            DTO.Add(new BloodPressureData(145, 90, 93));

            
            string path = @"Data.txt";

            if (File.Exists(path))
              {
                using StreamWriter sw = File.AppendText(path);
                foreach (BloodPressureData dtoData in DTO)
                {
                    sw.WriteLine(dtoData.Systolic + ";" + dtoData.Diastolic + ";" + dtoData.Pulse);

                }
                  sw.WriteLine();
                  sw.Close();
                
            }
        }
    }
}

