using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CalibrateWindow.xaml
    /// </summary>
    public partial class CalibrateWindow : Window
    {
        private readonly LineSeries _calibrateLine;
        private readonly MainWindow _mainRef;
        private GetADCvalues _getAdc;

        private List<double> _pressureValues;
        private List<double> _adcValues;

        public SeriesCollection Data { get; set; }
        public ChartValues<string> ADCValues { get; set; }
        public string PressureInput { get; set; }

        public CalibrateWindow()
        {
            InitializeComponent();
            _calibrateLine = new LineSeries();
            Data = new SeriesCollection();
            Data.Add(_calibrateLine);
            DataContext = this;
            _mainRef = new MainWindow();
            _pressureValues = new List<double>();
            _adcValues = new List<double>();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus();                                                                           //Cursor er i tekstboks, når vindue åbner

            _getAdc = new GetADCvalues();

            insertValues_Box.Text = "Indstil tryk til 0 mmHg";
            //CalibrateDone_Button.IsEnabled = false;

            Date_Box.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            _calibrateLine.Title = "Kalibreringspunkter";
            _calibrateLine.Values = new ChartValues<double>();
            ADCValues = new ChartValues<string>();
            DataContext = this;
            _calibrateLine.Fill = Brushes.Transparent;                                                       //Fjern farve under graf

        }

        private void CalibrateButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> pressureValue = new List<int>() { 0, 25, 50, 125, 200, 250, 200, 125, 50, 25, 0 }; ;
            int num = -1;

            string userInput;

            Fejlmeddelese_Box.Text = "";

            if (Values_box.Text != "" && int.TryParse(Values_box.Text, out num) && Convert.ToInt32(Values_box.Text) == pressureValue[_pressureValues.Count])              //Hvis userInput ikke er tom OG hvis userInput er en integer.
            {
                userInput = Values_box.Text;

                _calibrateLine.Values.Add(Convert.ToDouble(userInput));
                PressureInput = userInput;
                double adcInput = _getAdc.GetADCvaluesFromDataLayer();

                ADCValues.Add(Convert.ToString(adcInput));

                Values_box.Clear();
                Values_box.Focus();

                double pressure = Convert.ToDouble(PressureInput);                      //PressureInput - data binding
                _pressureValues.Add(pressure);
                _adcValues.Add(adcInput);

                if (_pressureValues.Count == 1)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[1] + " mmHg";
                }
                if (_pressureValues.Count == 2)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[2] + " mmHg";
                }
                if (_pressureValues.Count == 3)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[3] + " mmHg";
                }
                if (_pressureValues.Count == 4)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[4] + " mmHg";
                }
                if (_pressureValues.Count == 5)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[5] + " mmHg";
                }
                if (_pressureValues.Count == 6)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[6] + " mmHg";
                }
                if (_pressureValues.Count == 7)
                {
                    insertValues_Box.Text = "Indstil tryk tli " + pressureValue[7] + " mmHg";
                }
                if (_pressureValues.Count == 8)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[8] + " mmHg";
                }
                if (_pressureValues.Count == 9)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[9] + " mmHg";
                }
                if (_pressureValues.Count == 10)
                {
                    insertValues_Box.Text = "Indstil tryk til " + pressureValue[10] + " mmHg";
                }
                if (_pressureValues.Count == 11)
                {
                    //CalibrateDone_Button.IsEnabled = true;
                    calibrateButton.IsEnabled = false;
                    double[] adcValues = new double[11];                    //Array with x-values (adc [V])
                    double[] pressureValues = new double[11];               //Array with y-values (pressure [mmHg]

                    for (int i = 0; i < pressureValues.Length; i++)
                    {
                        pressureValues[i] = _pressureValues[i];
                        adcValues[i] = _adcValues[i];
                    }

                    LinearRegression regression = new LinearRegression(adcValues, pressureValues);

                    string a = Math.Round(regression.GetSlope(), 4).ToString();
                    string b = Math.Round(regression.GetIntercept(), 4).ToString();
                    string rSquared = Math.Round(regression.GetRSquared(), 4).ToString();

                    Regression_Box.Text = "y = " + a + " + " + b + "x\n R^2 = " + rSquared;
                    insertValues_Box.Text = "Kalibrering foretaget";
                }

            }
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";
            }

        }

        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); //Når der logges af, skjules kalibreringsvindue
            _mainRef.ShowDialog(); //og hovedvindue åbner

        }

        //private void CalibrateDone_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    double[] adcValues = new double[11];                    //Array with x-values (adc [V])
        //    double[] pressureValues = new double[11];               //Array with y-values (pressure [mmHg]

        //    for (int i = 0; i < pressureValues.Length; i++)
        //    {
        //        pressureValues[i] = _pressureValues[i];
        //        adcValues[i] = _adcValues[i];
        //    }

        //    LinearRegression regression = new LinearRegression(adcValues, pressureValues);

        //    string a = Math.Round(regression.GetSlope(), 4).ToString();
        //    string b = Math.Round(regression.GetIntercept(), 4).ToString();
        //    string rSquared = Math.Round(regression.GetRSquared(), 4).ToString();

        //    Regression_Box.Text = "y = " + a + " + " + b + "x\n R^2 = " + rSquared;
        //}
    }
}
