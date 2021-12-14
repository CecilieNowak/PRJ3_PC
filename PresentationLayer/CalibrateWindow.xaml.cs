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
using System.Xml.Serialization;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;
using LiveCharts.Configurations;
using DTO_BloodPressureData;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CalibrateWindow.xaml
    /// </summary>
    public partial class CalibrateWindow : Window
    {
        private readonly MainWindow _mainRef; //Reference til Main                                                                                          
        //private GetADCvalues _getAdc; //Test                                                                                    
        private List<int> pressureValue; //de ønskede trykværdier (defineret i UC1) findes her
        private List<double> _pressureValuesList; //indtastede trykværdier gemmes her                                                                                       
        private List<double> _adcValuesList; //aflæste ADC-værdier gemmes her                                                                                             
        private readonly ChartValues<Point> _values; //kalibreringspunkter til graf gemmes i denne variabel
        private CalibrateObserver calibrateObserver; //Oberser der attacher sig til bpSubject, for at få ADC-værdier (DTO.Værdi)
        private CalibrateValuesFile calibrateFile;
        private CalibrateData calibrateData;
        public BloodPressureSubject _subject;

        public SeriesCollection Data { get; set; } //Property bruges til at plotte trykværdi og ADC-værdi (med binding i xaml) 
        public string PressureInput { get; set; } //Property til indtastet trykværdi
        public double ADCValue { get; set; } //Property til ADC-værdi fra observermønster (bpSubject)

        public CalibrateWindow(MainWindow mainRef, BloodPressureSubject bp) 
        {
            InitializeComponent();
            _mainRef = mainRef; //Reference til Main (bruges til at kunne tilgå main ifm. log af og til at sætte A og B)
            _pressureValuesList = new List<double>();                                                                                    
            _adcValuesList = new List<double>();                                                                                        
            _values = new ChartValues<Point>();
            pressureValue = new List<int>() {0, 25, 50, 125, 200, 250, 200, 125, 50, 25, 0};

            _subject = new BloodPressureSubject();

            calibrateObserver = new CalibrateObserver(bp, this); //før bp, this
            calibrateFile = new CalibrateValuesFile();
            

        }

        //Når vinduet åbner
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus(); //Kurser er i tekstboks                                                                                                       
            insertValues_Box.Text = "Indstil tryk til 0 mmHg";
            Date_Box.Text = DateTime.Now.ToString("dd/MM/yyyy");
            calibrateButton.IsEnabled = true;
            
            //_getAdc = new GetADCvalues(_mainRef._filter, _mainRef._subject); //Test med testtråd
            //_getAdc = new GetADCvalues(); //Til test med random værdier


        }

        //Graf - se beskrivelse i bunden
        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            Data = new SeriesCollection                                                                                                 
            {
                new LineSeries
                {
                    Configuration = new CartesianMapper<Point>()
                        .X(point => point.X)
                        .Y(point => point.Y),
                    Title = "Kalibrering",
                    Values = _values,
                    Fill = Brushes.Transparent,

                }
            };
            DataContext = this; //Punkterne vises på kalibreringsgrafen ved at vores livechart binder denne Data.                                                                                                                                                             

        }

        //Denne metode returnere den tekst, der skal udskrives i vinduet - ift. hvilket tryk der skal indstilles til 
        private String UpdatePressure(int idx)                                                                                        
        {
            return "Indstil tryk til " + pressureValue[idx] + " mmHg";
        }

        //Når der trykkes på kalibreringsknappen
        private void calibrateButton_Click(object sender, RoutedEventArgs e)
        {
            Fejlmeddelese_Box.Text = "";
            int num = -1;
            string input = Values_box.Text;

            if (input != "" && int.TryParse(input, out num) && (Convert.ToInt32(input) == pressureValue[_pressureValuesList.Count] || Convert.ToInt32(input) <= pressureValue[_pressureValuesList.Count] + 2 && Convert.ToInt32(input) >= pressureValue[_pressureValuesList.Count] - 2))              //Hvis userInput ikke er tom OG hvis userInput er en integer.
            {
                PressureInput = Values_box.Text;  //Tryk input gemmes i en property
                double userInput = Convert.ToDouble(PressureInput); //Tryk konverteres til double
                //double adcValue = Convert.ToDouble(_getAdc.getADCvaluesFromDataLayer()); //til at teste adc værdi random 
                //double adcValue = Convert.ToDouble(_getAdc.GetADCvaluesFromDataLayer()); //til at teste adc værdi fra rpi

                double adcValue = ADCValue; //ADC værdi fra bpSubject (observermønster) gemmes i en variabel

                var point = new Point() { X = adcValue, Y = userInput}; //Der oprettes et nyt punkt. X = adc-værdi, Y = indtastet trykværdi
                _values.Add(point); //Punktet polottes i graf

                Values_box.Clear();
                Values_box.Focus();

                _pressureValuesList.Add(userInput); //Trykværdi gemmes i en liste, så den kan bruges til at lave regression 
                _adcValuesList.Add(adcValue); //ADC-værdi gemmes i en liste, så den kan bruges til at lave regression  

                if (_pressureValuesList.Count < 11)
                {
                    insertValues_Box.Text = UpdatePressure(_pressureValuesList.Count);
                }
                else if (_pressureValuesList.Count == 11)
                {
                    LinearRegression();
                }
            }
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";
                Values_box.Clear();
                Values_box.Focus();
            }

        }

        private void LinearRegression()
        {
            calibrateButton.IsEnabled = false; //Der kan ikke længere trykkes kalibrer
            double[] adcValues = new double[11]; //x-værdier                   
            double[] pressureValues = new double[11]; //y-værdier               

            //De gemte trykværdier og adc-værdier gemmes i to arrays - så der kan laves lineær regression med funktionen Fit.Line()  
            for (int i = 0; i < pressureValues.Length; i++)
            {
                pressureValues[i] = _pressureValuesList[i];
                adcValues[i] = _adcValuesList[i];
            }

            //De to arrays sættes ind som parametre i et nyt objekt for klassen LinearRegression
            LinearRegression regression = new LinearRegression(adcValues, pressureValues);

            //string a = Math.Round(regression.GetSlope(), 4).ToString(); //Hældningskoefficient beregnes med GetSlope()
            //string b = Math.Round(regression.GetIntercept(), 4).ToString(); //Skæring med y-akse beregnes GetIntercept()
            //string rSquared = Math.Round(regression.GetRSquared(), 4).ToString(); //r^2 beregnes med GetRSquared()

            double a = regression.GetSlope();
            double b = regression.GetIntercept();

            //Forskrift udskrives
            //regression.ToString();

            //if (regression.GetIntercept() < 0)
            //{
            //    Regression_Box.Text = "y = " + a + "x" + b + "\n R^2 = " + rSquared; //Hvis b er negativ, udskrives streng uden "+"
            //}
            //else
            //{
            //    Regression_Box.Text = "y = " + a + "x +  " + b + "\n R^2 = " + rSquared;
            //}
            Regression_Box.Text = regression.ToString();

            insertValues_Box.Text = "Kalibrering foretaget";

            //_mainRef.A = Convert.ToDouble(a);       //a gemmes i Main's property A
            //_mainRef.B = Convert.ToDouble(b);       //b gemmes i Main's property B

            calibrateData = new CalibrateData(a, b);

            calibrateFile.LogFile(calibrateData);

        }


        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            
            Environment.Exit(0);
            //this.Hide(); //Når der logges af, skjules kalibreringsvindue                                                                                                          

            //_subject.Remove(calibrateObserver);
            //_mainRef.PrepMainWindow(); //filter-observer tilføjes igen
            //_mainRef.ShowDialog();     
            //_mainRef.Show();
            

        }
    }
}

/*
 CalibrateGraph_Loaded:
 Der oprettes en ny instans af Data. Der oprettes også en ny kurve (LineSeries),som tilføjes til Data. 
 I kalibreringskurven tilføjes der punkter (Point), som består af et X- og Y-koordinat.
 Kurven får titlen "Kalibrering". Når der laves et nyt punkt, sættes det i Values.
 Farve under graf fjernes.
 */
