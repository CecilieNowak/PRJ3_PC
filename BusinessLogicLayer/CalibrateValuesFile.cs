using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataAccessLayer;
using DTO_BloodPressureData;
using MathNet.Numerics;


namespace BusinessLogicLayer
{
    public class CalibrateValuesFile
    {
        private CalibrateValues _calibrateValues = new CalibrateValues();
        private CalibrateData _calibrateDTO;


        public CalibrateValuesFile()
        {
            _calibrateValues = new CalibrateValues();
            _calibrateDTO = new CalibrateData();
        }

        public void LogCalFile(CalibrateData calibrateData)
        {
            _calibrateValues.LogFile(calibrateData);

        }

        public CalibrateData ReadFromFile()
        {
            return _calibrateDTO = _calibrateValues.ReadFromFile();
        }
    }
}
