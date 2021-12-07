using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class LogFileObserver : IBloodPressureObserver
    {
        private readonly Filter _filter;
        private readonly SaveDataToTxtfile _saveData;

        public LogFileObserver(Filter filter, SaveDataToTxtfile saveData)
        {
            _saveData = saveData;
            _filter = filter;
            filter.Add(this);
        }

        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
            BloodPressureData bp = new BloodPressureData();
            bp = _filter.getDTOSample();

            _saveData.LogFile(bp);
        }
    }
}
