using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    public sealed partial class BlankPage24hors : Page
    {
        public BlankPage24hors()
        {
            this.InitializeComponent();
           
          //  t.ButtonForegroundColor = Colors.White;
            this.ViewModel = new ClassViewModeNews();
           classComand = new ClassComand();
           zagruzka1();
          
           
        }
    
        ClassComand classComand;
        List<ClassNews> classNews;
        public async void Start()
        {
          try
            {
                //ViewModel.AddListNews(await classComand.zagruzka1(@"https://lenta.ru/rss/last24/", 10));
            }

            catch(Exception ex)
            {

            } 
            
        }
        public async Task zagruzka1()
        {

            try
            {

               

                   List<ClassNews> rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = ClassURI.News24, Istochnik = "Lenta.ru" }, 10)));
                    ViewModel.ListNews.Clear();

                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {
                            v.ButShow = true;
                        ViewModel.ListNews.Add(v);


                        }
                    }
                    rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vedomosti.ru/rss/issue", Istochnik = "Vedomosti.ru" }, 10)));
                    int poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {
                        foreach (var v in rSSFeedItems)
                        {
                            v.ButShow = true;
                            if (ViewModel.ListNews.Count > poz * 2 + 1)
                            {
                            ViewModel.ListNews.Insert(poz * 2 + 1, v);
                            }
                            else
                            {
                            ViewModel.ListNews.Add(v);
                            }


                            poz++;

                        }
                    }
                    if (ViewModel.ListNews.Count == 0)
                    {
                    ViewModel.ListNews.Add(new ClassNews() { Title = "Новостей по данной теме нет", Description = "Потяните вниз по списку данных что бы обновить.", ButShow = false, FigShow = false });


                    }
                
             

            }
            catch (Exception)
            {

            }

        }
        public ClassViewModeNews ViewModel { get; set; }

        private async void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridView GridViewNews = sender as GridView;
            ClassNews classNews = (ClassNews)GridViewNews.SelectedItem;
           // MessageDialog messageDialog = new MessageDialog(classNews.Description);
          //  await messageDialog.ShowAsync();
          
                BlankPageWeb blankPageWeb = new BlankPageWeb();
                blankPageWeb.hh = classNews.Link;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(BlankPageWeb), classNews.Link);
         


        }
    }
}
