using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics;

namespace BusinessLogicLayer
{
    public class LinearRegression
    {
        private readonly double[] _adcValues; //Array with x-values from the graph (adc [V])
        private readonly double[] _pressureValues; //Array with y-values from the graph (pressure [mmHg]
        private readonly Tuple<double, double> line;

        public double A { get; set; }
        public double B { get; set; }
        public double RSquared { get; set; }

        public LinearRegression(double[] adcValues, double[] pressureValues)
        {
            _adcValues = adcValues;
            _pressureValues = pressureValues;
            line = Fit.Line(_adcValues, _pressureValues);
        }

        public double GetSlope()
        {
            A = line.Item2;

            return A;
        }

        public double GetIntercept()
        {
            B = line.Item1;

            return B;
        }

        public double GetRSquared()
        {
            RSquared = GoodnessOfFit.RSquared(_adcValues.Select(x => B + A * x), _pressureValues);

            return RSquared;
        }
    }
}


