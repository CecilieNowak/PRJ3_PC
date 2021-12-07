using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;

namespace PresentationLayer
{
    class AlarmObserver : IBloodPressureObserver
    {

        private List<BloodPressureData> _local;
        private MainWindow mw;
        private readonly Filter _filter;

        public AlarmObserver(Filter filter, MainWindow mainWindow)
        {
            mw = mainWindow;
            _local = new List<BloodPressureData>();
            _filter = filter;
            filter.Add(this);
        }

        public void Update()
        {
            //for (int i = 1; i < 6; i++)
            //{
            //    BloodPressureData b = new BloodPressureData();
            //    b = _bp.GetNewestDTO();
            //    _local.Add(b);
            //    if (i >= 6)
            //    {


            //        if (_local[i].Systolic > 1.3 * _local[i - 5].Systolic || _local[i].Systolic < 0.7 * _local[i - 5].Systolic)
            //        {
            //            SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");
            //            alarm.PlayLooping();
            //        }
            //    }
            //}
            BloodPressureData bp = new BloodPressureData();


            bp = _filter.getDTOSample();
            

            //mw.Alarm(bp.Værdi);


            //for (int i = 6; i < 6; i++)
            //{
            //    if (_local[i].Systolic > 1.3 * _local[i - 5].Systolic || _local[i].Systolic < 0.7 * _local[i - 5].Systolic)
            //    {
            //        alarm.PlayLooping();
            //    }
            //}


            //kald getNewestDTO 6 antal gange, gem i lokal liste
            //if sætning med alarm algoritme med dto.Systolic

        }


    }
}