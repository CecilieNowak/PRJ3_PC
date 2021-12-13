using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;

namespace PresentationLayer
{
    class BatteryObserver : IBloodPressureObserver
    {
        private readonly Filter _filter;
        private readonly MainWindow mw;

        public BatteryObserver(Filter filter, MainWindow mainWindow)
        {
            mw = mainWindow;
            _filter = filter;
            filter.Add(this);
        }

        public void Update()                                            
        {
            //BatteryMonitorering battery = new BatteryMonitorering();

            BloodPressureData bp = new BloodPressureData();
            bp = _filter.getDTOSample();
            string batteri = Convert.ToString(bp.battery);
            mw.BatteryStatus(batteri);
            mw.updateBatteryBar(bp.battery);
        }
    }
}
