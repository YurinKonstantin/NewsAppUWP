using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace NewsAppUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageGeo : Page
    {
        public BlankPageGeo()
        {
            this.InitializeComponent();
        }
        Uri myUri2;
        Geo muGeo = new Geo();
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            object classNewsOb = (object)e.Parameter;
            ClassNews classNews = (ClassNews)classNewsOb;

            // if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            //  {
            Uri myUri = new Uri("https://yandex.ru/pogoda/moscow");



                web.Source = myUri;
            myUri2 = myUri;

           await MyParser();

            // }
            //  else
            // {
            //Uri myUri = new Uri(e.Parameter.ToString());
            // myUri2 = myUri;
            // web.Source = myUri;


            //}
            base.OnNavigatedTo(e);

        }
     public class Geo
        {
            public string tempNow { get; set; }
            public string UriIcon { get; set; }
        }
        public async Task MyParser()
        {
            var html = "<h1 style=\"color:red;\">Привет!</h1>" + "<a href=\"http://msdn.com/ru-ru/\">Русский MSDN</a>";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(myUri2);
            //  await prog.ProgressTo(.3, 250, Easing.Linear);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            html = responseBody;
           // muGeo.tempNow=
            int x = responseBody.IndexOf("temp__value");
         
            responseBody = responseBody.Substring(x);
            int x1 = responseBody.IndexOf("</span>");
         
            var temp = responseBody.Substring(13, 10);
            muGeo.tempNow = temp.Split('<')[0];
            tempT.Text = muGeo.tempNow;
            responseBody = responseBody.Substring(x1 + 5);
            x = responseBody.IndexOf("icon icon_color_light icon_size_48 icon_thumb_skc-n fact__icon");
            responseBody = responseBody.Substring(x+69);
            x1 = responseBody.IndexOf("/>");
            var dd = responseBody.Substring(0, x1-1);
          
            Img.Source = new SvgImageSource(new Uri("http:"+dd, UriKind.Absolute));
            MessageDialog messageDialog = new MessageDialog("http:" +dd);
            await messageDialog.ShowAsync();
            /* string varstr;
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
     */
           // web1.NavigateToString(html);
        }
    }
}
