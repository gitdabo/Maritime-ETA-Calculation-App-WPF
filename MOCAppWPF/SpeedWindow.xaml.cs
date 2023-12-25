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
    /// Interaction logic for SpeedWindow.xaml
    /// </summary>
    public partial class SpeedWindow : Window
    {
        public SpeedWindow()
        {
            InitializeComponent();
        }
        private void calculateSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDistanceValid;
            bool isTimeValid;

            isDistanceValid = double.TryParse(distanceTextBox.Text, out double distance);
            isTimeValid = double.TryParse(timeTextBox.Text, out double time);

            ETAWindow error = new ETAWindow();

            if (!isDistanceValid == true || !isTimeValid == true)
            {
                error.ErrorMessageHandling();
            }

            else if (distance <= 0 == true || time <= 0 == true )
            {
                error.ZeroErrorMessageHandling();
            }

            else
            {
                ComputeParameters parameters = new ComputeParameters(); 
                DisplayMessages display = new DisplayMessages();

                speedResultLabel.Text = display.DisplayResult(parameters.GetSpeed(time, distance),"Speed", "kts");
            }

        }
        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
