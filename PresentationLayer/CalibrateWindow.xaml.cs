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
        private LineSeries calibrateLine;
        private MainWindow mainRef;

        public SeriesCollection Data { get; set; }

        public CalibrateWindow()
        {
            InitializeComponent();
            calibrateLine = new LineSeries();

            Data = new SeriesCollection();

            Data.Add(calibrateLine);

            mainRef = new MainWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus();
        }

        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            calibrateLine.Title = "Kalibreringspunkter";

            calibrateLine.Values = new ChartValues<double>();         //Måske double?

            DataContext = this;

            calibrateLine.Fill = Brushes.Transparent;
            


        }

        private void calibrateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Values_box.Text != "")
            {
                calibrateLine.Values.Add(Convert.ToDouble(Values_box.Text));
                Values_box.Clear();

                Values_box.Focus();
            }
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";
            }
        }

        private void logOffButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainRef.ShowDialog();

        }

        private void Values_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)                                                   //Når adgangskode er indtastet, kan der logges ind ved at trykke Enter                                             
            {
                calibrateButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
