using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nav
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MONITORPOWER = 0xF170;
        private const int MONITOR_OFF = 2;

        public MainWindow()
        {
            this.InitializeComponent();
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            DateDisplay.Text = DateTime.Now.ToString("dddd");
            TimeDisplay.Text = DateTime.Now.ToString("hh:mm");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                TimeDisplay.Text = DateTime.Now.ToString("hh:mm");
                DateDisplay.Text = DateTime.Now.ToString("dddd");
            };
            timer.Start();

        }


        private void ScreenOffButton_Click(object sender, RoutedEventArgs e)
        {
            IntPtr handle = GetForegroundWindow();
            SendMessage(handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MONITOR_OFF);

        }

        private void AAButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VolumeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
