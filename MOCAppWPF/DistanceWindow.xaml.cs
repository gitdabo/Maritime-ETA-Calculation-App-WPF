using MaritimeAppLibrary;
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
using System.Windows.Shapes;

namespace MOCAppWPF
{
    /// <summary>
    /// Interaction logic for DistanceWindow.xaml
    /// </summary>
    public partial class DistanceWindow : Window
    {
        public DistanceWindow()
        {
            InitializeComponent();
        }

        private void calculateDistanceButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSpeedValid;
            bool isTimeValid;

            isSpeedValid = double.TryParse(speedTextBox.Text, out double speed);
            isTimeValid = double.TryParse(timeTextBox.Text, out double time);

            ETAWindow error = new ETAWindow();  

            if (!isSpeedValid == true || !isTimeValid == true)
            {
                error.ErrorMessageHandling();
            }

            else if (speed <= 0 || time <= 0)
            {
                error.ZeroErrorMessageHandling();
            }

            else
            {
                ComputeParameters parameters = new ComputeParameters(); 
                DisplayMessages display = new DisplayMessages();

                distanceResultLabel.Text = display.DisplayResult(parameters.GetDistance(time, speed), "Distance","Nm");
            }

        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
