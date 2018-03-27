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
using System.Windows.Shapes;

namespace UWP_Editorial_App
{
    /// <summary>
    /// Interaction logic for moreDetailPage.xaml
    /// </summary>
    public partial class moreDetailPage : Window
    {
        ConfigMeths SystemMethods = new ConfigMeths();
        TransitionClass TransClass = new TransitionClass();

        public bool AlreadyLoaded = false;

        private bool Updated
        {
            set
            {
                if (value)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
            }
        }

        public moreDetailPage(string FolderPath)
        {
            InitializeComponent();

            //var item = new RowDefinition();
            //item.Height = new GridLength(100);
            //GridOfData.RowDefinitions.Add(item);
            var Path = SystemMethods.GetFile(FolderPath.Replace("file:///", "") + "/BackGround");
            if (Path != null)
                this.Background = new ImageBrush(new BitmapImage(Path));

            FilePath = FolderPath;
            LoopThroughFiles();

        }

        

        private string FilePath { get; set; }

        private void LoopThroughFiles()
        {
            var item = SystemMethods.GetFiles(FilePath.Replace("file:///",""));

            foreach (var FileItem in item)
            {
                AddFile(FileItem.FullName);
            }
        }

        private void AddFile(string ItemFilePath)
        {
            var item = new RowDefinition();
            MediaElement ItemFile = new MediaElement();
            ItemFile.Source = new Uri(ItemFilePath);
            ItemFile.MediaEnded += delegate
            {
                ItemFile.Position = TimeSpan.FromSeconds(0);
            };
            ItemFile.Volume = 0;

            item.Height = new GridLength((System.Windows.SystemParameters.WorkArea.Height / 5) * 4);
            ItemFile.MouseLeftButtonUp += delegate
            {
                FullScreen Screen = new FullScreen(ItemFile.Source);
                Screen.Show();
            };
            GridOfData.RowDefinitions.Add(item);
            ItemFile.HorizontalAlignment = HorizontalAlignment.Center;
            GridOfData.Children.Add(ItemFile);
            Grid.SetRow(ItemFile, GridOfData.RowDefinitions.Count - 1);

            item = new RowDefinition();
            item.Height = new GridLength(10);
            GridOfData.RowDefinitions.Add(item);
        }


        private void TransThread()
        {
            bool IsVisible = false;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                IsVisible = TransGrid.Visibility == Visibility.Visible;
            }));
            if (IsVisible)
                TransClass.Transition(1, 0, TransGrid);
            else
            {
                TransClass.Transition(0, 1, TransGrid);
                Updated = true;
            }

            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(TransThread));
            t1.Start();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (!AlreadyLoaded)
            {
                AlreadyLoaded = true;
                Thread t1 = new Thread(new ThreadStart(TransThread));
                t1.Start();
            }
        }
    }
}
