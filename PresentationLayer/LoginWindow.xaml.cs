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
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly MainWindow _mainWRef;
        private readonly CheckLogin _logicRef;


        public LoginWindow(MainWindow mainW, CheckLogin logicRef)
        {
            InitializeComponent();
            _mainWRef = mainW;
            _logicRef = logicRef;
        }

        private void LogIn_button_Click(object sender, RoutedEventArgs e)
        {
            if (_logicRef.LoginCheck(Username_txtbox.Text, Password_txtbox.Text) == true)
            {
                _mainWRef.LoginOk = true;
                this.Close();
            }
            else
            {
                fejlmeddelelse_Box.Text = "Fejl i brugernavn eller adgangskode";
                Username_txtbox.Text = "";
                Password_txtbox.Text = "";
                Username_txtbox.Focus();
            }

        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _mainWRef.ShowDialog();
        }

        private void Password_txtbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) //Når adgangskode er indtastet, kan der logges ind ved at trykke Enter                                             
            {
                LogIn_button_Click(this, new RoutedEventArgs());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Username_txtbox.Focus();
            Date_box.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Dato vises på UI
            //kode til at vise tid
        }
    }

}
