using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO_BloodPressureData;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CheckLogin _logicobj;
        private LoginWindow _loginW;

        public bool LoginOk { get; set; }
        public String Username { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _logicobj = new CheckLogin();
            _loginW = new LoginWindow(this, _logicobj);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date_box.Text = DateTime.Now.ToString("dd/MM/yyyy");                        //Dato vises på UI
            //Der skal måske også være kode til at vise tid her
        }

        private void BP_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Puls_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveData_button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Calibrate_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();                                                                        //Når der klikkes på Kalibrer-knappen, lukker hovedvindue
            _loginW.ShowDialog();                                                               //og Loginvindue vises

            if (LoginOk == true)                                                                
            {
                this.ShowDialog();                                                              //Hvis Login er ok, fuldføres login, og vi kommer tilbage til hovedvinduet
            }
            else
            {
                this.Close();                                                                   //Hvis Login er forkert, kommer vi ikke tilbage til hovedvinduet
            }
        }

        private void CPR_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Close_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);                                                                //Program lukker, når der trkkes på Luk-knappen
        }
    }
}
