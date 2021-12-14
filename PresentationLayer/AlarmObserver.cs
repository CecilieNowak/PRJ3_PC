using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public class AlarmObserver : IBloodPressureObserver
    {
        private readonly Filter _filter;
        private readonly MainWindow mw;
        private Ellipse _alarmEllipse;


        public AlarmObserver(Filter filter, MainWindow mainWindow, Ellipse alarmEllipse)
        {
            mw = mainWindow;
            _filter = filter;
            _alarmEllipse = alarmEllipse;
            filter.Add(this);
        }

        //bool b = false;
        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
            BloodPressureData bp = new BloodPressureData();
            bp = _filter.getDTOSample();
            List<double> sysList = _filter.getListOfSys(); // fjernet mw. i mw._filter.getListOfSys();
            List<double> diaList = _filter.GetListOfDia();

            mw.AlarmVisibility(sysList);
        }
    }
}