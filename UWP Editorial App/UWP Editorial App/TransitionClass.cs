using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UWP_Editorial_App
{
    public class TransitionClass
    {
        private double Add(double a, double b) { return a + b; }
        private double Subtract(double a, double b) { return a - b; }

        private bool GreaterThan(double a, double b) { return a < b; }
        private bool LessThan(double a, double b) { return a > b; }

        private bool TransComplete { get; set; }

        delegate double Operation(double a, double b);
        delegate bool OperationGreater(double a, double b);

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        // returns seconds since last input
        long GetIdleTime()
        {
            var info = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO)) };
            GetLastInputInfo(ref info);
            return (Environment.TickCount - info.dwTime) / 1000;
        }

        public TransitionClass()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
            timer.Tick += (s, e) =>
            {
                if (GetIdleTime() > 0.5 * 60) // 10 min
                {
                    ScreenSaver SS = new ScreenSaver();
                    SS.ShowDialog();
                }

            };
        }

        public bool Transition(double StartingTrans, double EndingTrans, Grid grdObject)
        {
            Operation Op;
            OperationGreater Gp;
            if (StartingTrans > EndingTrans)
            {
                Op = Subtract;
                Gp = LessThan;
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Op = Add;
                Gp = GreaterThan;
            }
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                grdObject.Visibility = Visibility.Visible;
            }), DispatcherPriority.Send);
            do
            {
                System.Threading.Thread.Sleep(50);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    grdObject.Opacity = Convert.ToDouble(StartingTrans);
                }), DispatcherPriority.Send);
                StartingTrans = Op(StartingTrans,0.05);
            } while (Gp(StartingTrans, EndingTrans));

            if (Op == Subtract)
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    grdObject.Visibility = Visibility.Hidden;
                }), DispatcherPriority.Send);
            return true;
        }
    }
}
