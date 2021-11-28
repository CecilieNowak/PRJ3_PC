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
        //Klassen observerer på subject i BLL og implementerer interfacet IbloodpressureObserver
            
        
        private readonly Filter _filter;
        private readonly MainWindow mw;
         
        

        public DisplayObserver(Filter filter, MainWindow mainWindow)
        {
            mw = mainWindow;
            _filter = filter;
            filter.Add(this);
            

        }

        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
            BloodPressureData bp = new BloodPressureData();
              bp = _filter.display();
          // BloodPressureData subject = _bp.GetNewestDTO();              //Her hentes den nyeste DTO som er tilføjet til subjectet og gemmes i en ny variable 
           mw.YValues.Add(bp.Værdi);
           mw.XValues.Add(1);


           mw.UpdatePulseTextBox(Convert.ToString(bp.Værdi));      //Her kaldes metoden updatePulsTextBox som opdaterer textboxen med pulsværdien fra den modtagede DTO


        }
        
    }

 
}
