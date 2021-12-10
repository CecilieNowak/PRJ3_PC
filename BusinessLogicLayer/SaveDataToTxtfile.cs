using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class SaveDataToTxtfile
    {
        private string path;
        public Filter _filter;
        public BloodPressureSubject _subject;


        public SaveDataToTxtfile()
        {
            _subject = new BloodPressureSubject();
            _filter = new Filter(_subject);
            LogFileObserver logFile = new LogFileObserver(_filter, this);
            path = @"Data.txt";
        }

        public void LogFile(BloodPressureData bp)
        {
            List<BloodPressureData> DTO = new List<BloodPressureData>();

            //DTO.Add(new BloodPressureData(140,90,90));
            //DTO.Add(new BloodPressureData(130, 95, 90));
            //DTO.Add(new BloodPressureData(145, 90, 93));

            DTO.Add(new BloodPressureData(bp.Systolic, bp.Diastolic, bp.Pulse));

            if (File.Exists(path))
            {
                using StreamWriter sw = File.AppendText(path);
                foreach (BloodPressureData dtoData in DTO)
                {
                    sw.WriteLine(dtoData.Systolic + ";" + dtoData.Diastolic + ";" + dtoData.Pulse);
                }

                sw.Close();
            }
        }

        public void DeleteFromFile()
        {
            File.Delete(path);

            if (!File.Exists(path))
            {
                using StreamWriter sw = File.AppendText(path);
            }
        }
    }
}

