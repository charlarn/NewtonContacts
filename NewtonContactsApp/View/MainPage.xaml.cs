using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewtonContactsApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private double currentSize = 0;
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1020, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.SizeChanged += WindowSizeChanged;
        }

        private void contactsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridMain.ActualWidth < 600)
            {
                Frame.Navigate(typeof(DetailsView), contactsView.SelectedItem);
            }
            else
            {
                VisualStateManager.GetVisualStateGroups(this);
                Debug.WriteLine("big:" + gridMain.ActualWidth);
            }
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
   
        }

        private void gridMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            currentSize = e.NewSize.Width;
            Debug.WriteLine("C: " + currentSize);
        }
    }
}
