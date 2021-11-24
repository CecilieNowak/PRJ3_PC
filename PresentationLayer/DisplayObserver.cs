﻿using System;
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
            
        
        private BloodPressureSubject _bp;
        private MainWindow mw;
        

        public DisplayObserver(BloodPressureSubject bp, MainWindow mainWindow)
        {
            mw = mainWindow;
            _bp = bp;
            _bp.Add(this);

            
        }

        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
           BloodPressureData subject = _bp.getNewestDTO();              //Her hentes den nyeste DTO som er tilføjet til subjectet og gemmes i en ny variable 
           mw.YValues.Add(subject.Pulse);
           mw.XValues.Add(1);

           mw.updatePulseTextBox(Convert.ToString(subject.Pulse));      //Her kaldes metoden updatePulsTextBox som opdaterer textboxen med pulsværdien fra den modtagede DTO


        }
        
    }

 
}
