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
            RSquared = GoodnessOfFit.RSquared(_adcValues.Select(x => A * x + B), _pressureValues);

            return RSquared;
        }

        public override string ToString()
        {
            if (GetIntercept() < 0)
            {
                return "y = " + Math.Round(A, 2)  + "x" + Math.Round(B, 2) + "\t R^2 = " + Math.Round(RSquared, 2); //Hvis b er negativ, udskrives streng uden "+"
            }
            else
            {
                return "y = " + Math.Round(A, 2) + "x +  " + Math.Round(B, 2) + "\t R^2 = " + Math.Round(RSquared, 2);
            }
        }
    }
}


