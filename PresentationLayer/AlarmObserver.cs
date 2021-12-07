using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
using PresentationLayer;

namespace BusinessLogicLayer
{
    public class AlarmObserver : IBloodPressureObserver
    {

        private List<double> _local_sys;
        private List<double> _local_dia;
        private Alarm _alarm;

        private readonly Filter _filter;
        private Ellipse alarm1;
        private MainWindow _mw;
        private Storyboard st;

        public AlarmObserver(Filter filter, Ellipse alarmEllipse, MainWindow mw)
        {
            st = new Storyboard();
            _alarm = new Alarm(alarmEllipse,mw, st);
            _local_sys = new List<double>();
            _local_dia = new List<double>();
            _filter = filter;
            alarm1 = alarmEllipse;
            _mw = mw;
            filter.Add(this);
        }

        public void Update()
        {
            _local_dia = _filter.GetListOfDia();
            _local_sys = _filter.getListOfSys();

            _alarm.Alarmblink(_local_sys,_local_dia,250,10);
            _alarm.StartAlarm(_local_dia,_local_sys);

            

            //kald getNewestDTO 6 antal gange, gem i lokal liste
            //if sætning med alarm algoritme med dto.Systolic


        }


    }
}