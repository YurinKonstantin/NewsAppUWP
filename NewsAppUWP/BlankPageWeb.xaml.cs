using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace NewsAppUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageWeb : Page
    {
        public BlankPageWeb()
        {
            this.InitializeComponent();
        
        }
        public string hh;
        Uri myUri2;
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            object classNewsOb = (object)e.Parameter;
            ClassNews classNews = (ClassNews)classNewsOb;

           // if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
          //  {
                Uri myUri = new Uri(classNews.Link);
                

                if (classNews.istochnic=="Lenta.ru")
                {
                myUri2 = myUri;
               await MyParser();
            }
                else
                  {
                web.Source = myUri;
                myUri2 = myUri;
                 }
                    
           // }
          //  else
           // {
               //Uri myUri = new Uri(e.Parameter.ToString());
               // myUri2 = myUri;
               // web.Source = myUri;
            

            //}
            base.OnNavigatedTo(e);
          
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }
        public async Task MyParser()
        {
            var html = "<h1 style=\"color:red;\">Привет!</h1>" + "<a href=\"http://msdn.com/ru-ru/\">Русский MSDN</a>";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(myUri2);
            //  await prog.ProgressTo(.3, 250, Easing.Linear);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            int x = responseBody.IndexOf("<h1");

            responseBody = responseBody.Substring(x);
            int x1 = responseBody.IndexOf("</h1>");
            html = responseBody.Substring(0, x1 + 5);
            responseBody = responseBody.Substring(x1 + 5);
            string varstr;
            x = responseBody.IndexOf("<img");
            varstr = responseBody.Substring(x);
            x1 = varstr.IndexOf("/>");
            varstr = varstr.Substring(0, x1 + 2);

            html += varstr;
            x = responseBody.IndexOf("<p>");
            responseBody = responseBody.Substring(x);
            x1 = responseBody.LastIndexOf("p>");
            //html += responseBody.Substring(0, x1 + 4);


            html += responseBody.Substring(0, x1 + 3);
            string viriz;
            int s = html.IndexOf("<aside");
            // viriz = responseBody.Substring(s);
            int xs = html.IndexOf("</aside>");
            //viriz = viriz.Substring(0, xs + 8);
            html = html.Remove(s, xs - s);
            //MessageDialog messageDialog = new MessageDialog(varstr);
            //await messageDialog.ShowAsync();
            web.NavigateToString(html);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var html = "<h1 style=\"color:red;\">Привет!</h1>" + "<a href=\"http://msdn.com/ru-ru/\">Русский MSDN</a>";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(myUri2);
            //  await prog.ProgressTo(.3, 250, Easing.Linear);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            int x = responseBody.IndexOf("<h1");
          
            responseBody = responseBody.Substring(x);
            int x1 = responseBody.IndexOf("</h1>");
            html = responseBody.Substring(0, x1 + 5);
            responseBody = responseBody.Substring(x1 + 5);
            string varstr;
            x= responseBody.IndexOf("<img");
            varstr = responseBody.Substring(x);
            x1 = varstr.IndexOf("/>");
            varstr = varstr.Substring(0, x1+2);

            html += varstr;
            x = responseBody.IndexOf("<p>");
            responseBody = responseBody.Substring(x);
            x1 = responseBody.LastIndexOf("p>");
            //html += responseBody.Substring(0, x1 + 4);
  
      
            html += responseBody.Substring(0, x1 + 3);
            string viriz;
            int s = html.IndexOf("<aside");
           // viriz = responseBody.Substring(s);
            int xs= html.IndexOf("</aside>");
            //viriz = viriz.Substring(0, xs + 8);
            html = html.Remove(s, xs-s);
            MessageDialog messageDialog = new MessageDialog(varstr);
            await messageDialog.ShowAsync();
            web1.NavigateToString(html);
        }
    }
}
