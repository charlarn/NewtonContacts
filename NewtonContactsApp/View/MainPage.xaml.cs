using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Core;
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
        ControlTemplate addContact, detailsTemplate;
        private VisualStateGroup visualStates;

        public MainPage()
        {
            InitializeComponent();
          //  SystemNavigationManager
                          //      .GetForCurrentView()
                          //     .AppViewBackButtonVisibility
                          //      = AppViewBackButtonVisibility.Visible;
          //  SystemNavigationManager
                 //   .GetForCurrentView()
                  //  .BackRequested += RootHost_BackRequested;
           // this.Loaded += RootHost_Loaded;
            ApplicationView.PreferredLaunchViewSize = new Size(1020, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            visualStates = VisualStateManager.GetVisualStateGroups(gridMain).ToList()[0];
            addContact = Resources["addContactTemplate"] as ControlTemplate;
            detailsTemplate = Resources["detailsTemplate"] as ControlTemplate;
        }

        private void contactsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(visualStates.CurrentState == null)
            {
                Frame.Navigate(typeof(DetailsView), new { Contact = controller.SelectedContact, Template = detailsTemplate });
            }
            else if (detailsView.Template != detailsTemplate)
            {
                 detailsView.Template = detailsTemplate;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.Contacts.Remove(controller.SelectedContact);
        }

        public static double ScreenRezWidth()
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
            return size.Width;
        }

        private void buttonAddContact_Click(object sender, RoutedEventArgs e)
        {
            if (detailsView.Template != addContact)
                detailsView.Template = addContact;
        }
    }
}
