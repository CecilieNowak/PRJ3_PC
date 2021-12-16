using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;



namespace PresentationLayer
{
    class DisplayObserver : IBloodPressureObserver
    {
        //Klassen observerer på subject i BLL og implementerer interfacet IbloodpressureObserver


        private readonly Filter _filter;
        private readonly MainWindow mw;
        public DateTime _datetime { get; set; }



        public DisplayObserver(Filter filter, MainWindow mainWindow)
        {
            mw = mainWindow;
            _filter = filter;
            filter.Add(this);
            

        }

        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
            DateTime now = DateTime.Now;
            BloodPressureData bp = new BloodPressureData();
            CalibrateData cd = new CalibrateData();
            bp = _filter.getDTOSample();           


            mw.AddDisplayValues(bp); 

            mw.XValues.Add(now.ToString());


            //Her kaldes metoden updatePulsTextBox som opdaterer textboxen med pulsværdien fra den modtagede DTO
            mw.UpdatePulseTextBox(Convert.ToString(Convert.ToInt32(bp.Værdi)));
            mw.UpdateDiaSysTextbox(bp.Systolic, bp.Diastolic);

            string batteri = Convert.ToString(bp.battery);
            mw.BatteryStatus(batteri);
            mw.updateBatteryBar(bp.battery);

        }
    }
}