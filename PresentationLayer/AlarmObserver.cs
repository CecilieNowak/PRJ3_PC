using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using System.Media;

namespace PresentationLayer
{
    class AlarmObserver
    {

        private BloodPressureSubject _bp;
        private MainWindow mw;


        public AlarmObserver(BloodPressureSubject bp, MainWindow mainWindow)
        {
            mw = mainWindow;
            _bp = bp;
            _bp.Add(this);
        }

        SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");
        public void Update()                                       
        { 
            BloodPressureData subject = _bp.getNewestDTO();

            void StartAlarm(List<int> _bp)
            {
                for (int i = 5; i <= _bp.Count - 5; i++)
                {
                    if (_bp[i] > 1.3 * _bp[i - 5] || _bp[i] < 0.7 * _bp[i - 5])
                    {
                        alarm.PlayLooping();

                    }

                }

            }


        }
    }


}
