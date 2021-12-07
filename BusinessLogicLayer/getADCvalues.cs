using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GetADCvalues
    {
        private readonly ReadADCValues adc;
        private Filter _filter;
        private BloodPressureSubject _bloodPressureSubject;
        public GetADCvalues()
        {
            adc = new ReadADCValues();
        }

        public GetADCvalues(Filter filter, BloodPressureSubject subject)
        {
            _filter = filter;
            _bloodPressureSubject = subject;

        }

        //public double GetADCvaluesFromDataLayer()
        //{

        //    double adcValue = _filter.getSmoothDTO().Værdi;

        //    return adcValue;

        //    //return adc.ReadAdcValues();
        //}

        public double getADCvaluesFromDataLayer()
        {
            double adcValue = adc.ReadAdcValues();

            return adcValue;
        }
    }
}
