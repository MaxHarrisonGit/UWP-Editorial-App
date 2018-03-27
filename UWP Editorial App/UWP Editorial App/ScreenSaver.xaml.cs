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
    /// Interaction logic for ScreenSaver.xaml
    /// </summary>
    public partial class ScreenSaver : Window
    {
        ConfigMeths SystemMethods = new ConfigMeths(true);
        public ScreenSaver()
        {
            InitializeComponent();
            var Video = SystemMethods.GetScreenSaverVideo;
            if (Video != null)
                ScreenSaverVideo.Source = SystemMethods.GetScreenSaverVideo;
            else
                MessageBox.Show("Screen Saver Video has not been found. Please insert a Video into the 'ScreenSaverVideo' area.");
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
