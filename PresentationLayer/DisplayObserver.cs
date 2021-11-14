using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using LiveCharts;
using LiveCharts.Wpf;

using BusinessLogicLayer;
using DTO_BloodPressureData;
using Microsoft.Identity.Client;


namespace PresentationLayer
{
    class DisplayObserver : IBloodPressureObserver
    {
        
        
        private BloodPressureSubject _bp;
        private MainWindow mw;
        

        public DisplayObserver(BloodPressureSubject bp, MainWindow mainWindow)
        {
            mw = mainWindow;
            _bp = bp;
            _bp.Add(this);

            
        }

        public void Update()
        {
           BloodPressureData subject = _bp.getNewestDTO();
           mw.YValues.Add(subject.Pulse);
           mw.XValues.Add(1);
        }
        
    }

 
}
