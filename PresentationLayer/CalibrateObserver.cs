using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO_BloodPressureData;
using BusinessLogicLayer;
using MathNet.Numerics.Optimization.ObjectiveFunctions;

namespace PresentationLayer
{
    class CalibrateObserver : IBloodPressureObserver //Klassen observerer på subject i BLL og implementerer interfacet IbloodpressureObserver
    {
        //Skal jeg bruge smooth-metoden fra filtret?

        private readonly BloodPressureSubject _bpSubject;
        private readonly CalibrateWindow _calibrateW;
        private List<BloodPressureData> _getDTO;

        public CalibrateObserver(BloodPressureSubject bpSubject, CalibrateWindow calibrateW)
        {
            _calibrateW = calibrateW;
            _bpSubject = bpSubject;
            bpSubject.Add(this); //Observer attacher til bsSubject?

            _getDTO = new List<BloodPressureData>();

        }

        public void Update()                                            //Metoden henter nyeste DTO fra subjectet og opdaterer livecharten (Lige nu opdaterer den kun puls!)
        {
            _getDTO = _bpSubject.GetNewestDTO(); //Vi gemmer de nyeste DTO'er i en liste
            

            //if (_getDTO.Count == 10) //Ved ikke om det skal være == 10
            //{
            //    _getDTO.RemoveAt(0); //Hver gang der er modtaget 10 DTO'er, fjernes DTO'en på plads 0 i listen. 
            //}

            _calibrateW.ADCValue = _getDTO.Last().Værdi; //Den nyeste værdi i listen bliver parameter-værdi for metoden GetADC i kalibreringsvinduet
        }
    }
}
