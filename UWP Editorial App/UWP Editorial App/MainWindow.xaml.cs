using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace UWP_Editorial_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //There is a blinking issue when the screen transitions to the new screen, This can be resolved by making it all into one window and have the grids hide and show when needed.
        ConfigMeths SystemMethods = new ConfigMeths(true);
        TransitionClass TransClass = new TransitionClass();
        moreDetailPage DetailPage;
        private bool Updated
        {
            set
            {
                if(value)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.Hide();
                        DetailPage.ShowDialog();
                        this.Show();
                        Thread t1 = new Thread(new ThreadStart(TransThread));
                        t1.Start();
                    }));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            PopulateFrontScreen();
        }


        private string DetailLocation { get; set; }

        #region CatalogueView
        private void PopulateFrontScreen()
        {
            int NumberOfFiles = SystemMethods.FilesInCatalogue - 1;
            var result = PopulateLoop(0, NumberOfFiles);
        }

        private KeyValuePair<int, Boolean> PopulateLoop(int FileCounter, int NumberOfFiles)
        {
            bool Looped = false;
            foreach (var c in parentGrid.Children)
            {
                if (c.GetType() == typeof(Grid))
                {
                    if (FileCounter > NumberOfFiles) { FileCounter = 0; Looped = true; }
                    Grid SelectedGrid = (Grid)c;
                    MediaElement Element = (MediaElement)SelectedGrid.Children[0];
                    Element.Source = SystemMethods.GetCatalogueIcon(FileCounter);
                    Element.MouseLeftButtonUp += delegate
                    {
                        //DetailLocation = Element.Source.ToString().Substring(0, Element.Source.ToString().IndexOf("/ThumbNail"));
                        //View(true);
                        DetailPage = new moreDetailPage(Element.Source.ToString().Substring(0, Element.Source.ToString().IndexOf("/ThumbNail")));
                        Thread t1 = new Thread(new ThreadStart(TransThread));
                        t1.Start();

                    };
                    FileCounter++;
                }
            }
            return new KeyValuePair<int, bool>(FileCounter, Looped);
        }

        

        private void TransThread()
        {
            bool IsVisible = false;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                IsVisible = TransGrid.Visibility == Visibility.Visible;
            }), DispatcherPriority.Send);
            if (IsVisible)
                TransClass.Transition(1, 0, TransGrid);
            else
            {
                TransClass.Transition(0, 1.25, TransGrid);
                Updated = true;
            }

            
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var Media = (MediaElement)sender;
            Media.Position = TimeSpan.FromSeconds(0);
        }

        #endregion
    }

}
