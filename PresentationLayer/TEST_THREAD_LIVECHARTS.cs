using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using System.Threading.Tasks;
using System.Threading;

namespace PresentationLayer
{
    class TEST_THREAD_LIVECHARTS
    {
        private MainWindow _mainWindow;
        private BloodPressureSubject _bp;
        private Random random;

        public TEST_THREAD_LIVECHARTS(MainWindow mw, BloodPressureSubject bp)
        {
            _mainWindow = mw;
            _bp = bp;
            random = new Random();
        }

        public void updateChart()
        {
            for (int i = 0; i < 100; i++)
            {
                BloodPressureData testData = new BloodPressureData();
                testData.Pulse = random.Next(50, 190);
                testData.Systolic = random.Next(90, 120);
                testData.Diastolic = random.Next(40, 80);

                _bp.newDataRecieved(testData);
                
                Thread.Sleep(1000);
            }
        }
    }
}
