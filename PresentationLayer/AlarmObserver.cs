using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using System.Media;

namespace PresentationLayer
{
    class AlarmObserver : IBloodPressureObserver
    {

        private BloodPressureSubject _bp;
        private MainWindow mw;


        public AlarmObserver(BloodPressureSubject bp, MainWindow mainWindow)
        {
            mw = mainWindow;
            _bp = bp;
            _bp.Add(this);
        }

        
        public void Update()                                       
        {
            SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");
            alarm.PlayLooping();
        }


    }
}
