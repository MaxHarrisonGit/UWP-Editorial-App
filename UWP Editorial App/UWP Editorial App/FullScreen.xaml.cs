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

namespace UWP_Editorial_App
{
    /// <summary>
    /// Interaction logic for FullScreen.xaml
    /// </summary>
    public partial class FullScreen : Window
    {
        public FullScreen(Uri Location)
        {
            InitializeComponent();
            MediaFile.Source = Location;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaFile.Volume = e.NewValue;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MediaFile_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaFile.Position = TimeSpan.FromSeconds(0);
        }
    }
}
