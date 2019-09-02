using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace NewsAppUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
          //  var t = ApplicationView.GetForCurrentView().TitleBar;
          //  t.BackgroundColor = Colors.CadetBlue;
          //  t.ForegroundColor = Colors.CadetBlue;
          //  t.ButtonBackgroundColor = Colors.CadetBlue;
            
        }
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
           
        

            // set the initial SelectedItem 
            
                
                    NavView.SelectedItem = NavView.MenuItems[0];
                    NavView.Header = "Главное";
                    NavView.IsSettingsVisible = true;
                    NavView.Language = "ru-Ru";
                    ContentFrame.Navigate(typeof(PivotPageGlavnoe));
                    
                
            

           

            // add keyboard accelerators for backwards navigation
            KeyboardAccelerator GoBack = new KeyboardAccelerator();
            GoBack.Key = VirtualKey.GoBack;
            GoBack.Invoked += BackInvoked;
            KeyboardAccelerator AltLeft = new KeyboardAccelerator();
            AltLeft.Key = VirtualKey.Left;
            AltLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(GoBack);
            this.KeyboardAccelerators.Add(AltLeft);
            // ALT routes here
            AltLeft.Modifiers = VirtualKeyModifiers.Menu;
           


        }
        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;

        }
        private bool On_BackRequested()
        {
            bool navigated = false;

            // don't go back if the nav pane is overlayed
            if (NavView.IsPaneOpen && (NavView.DisplayMode == NavigationViewDisplayMode.Compact || NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
            {
                return false;
            }
            else
            {
                if (ContentFrame.CanGoBack)
                {
                    ContentFrame.GoBack();
                    navigated = true;
                }
            }
            return navigated;
        }
        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Glavnoe":
                   ContentFrame.Navigate(typeof(PivotPageGlavnoe));
                    NavView.Header = "Главное";
        
                    break;

                case "Rus":
                    ContentFrame.Navigate(typeof(PivotPageRus));
                    NavView.Header = "Россия";
                    break;

                case "World":
                    // ContentFrame.Navigate(typeof(GamesPage));
                    break;

                case "Sport":
                    //  ContentFrame.Navigate(typeof(MusicPage));
                    break;

                case "Econom":
                    //  ContentFrame.Navigate(typeof(MyContentPage));
                    break;
                case "Zac":
                    //  ContentFrame.Navigate(typeof(MyContentPage));
                    break;
                case "geo":
                      ContentFrame.Navigate(typeof(BlankPageGeo));
                    break;
            }
        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
           // On_BackRequested();

        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }
    }
}
