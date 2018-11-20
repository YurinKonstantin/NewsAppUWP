using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class PivotPageGlavnoe : Page
    {
        public PivotPageGlavnoe()
        {
            this.InitializeComponent();
            this.ViewModel = new ClassViewModeNews();
            classComand = new ClassComand();
            
        }
        ClassComand classComand;
        List<ClassNews> classNews;
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

          //  BlankPageWeb blankPageWeb = new BlankPageWeb();
          //  blankPageWeb.hh = classNews.Link;
         //   Frame rootFrame = Window.Current.Content as Frame;
         //   rootFrame.Navigate(typeof(BlankPageWeb), classNews.Link);
            this.Frame.Navigate(typeof(BlankPageWeb), classNews);



        }
        public async Task zagruzka1RusAll()
        {

            
               

                
                    // Connection to internet is available

                    List<string> arayUri = new List<string>();
                    //var Urr = ClassURI.News24;
                    // await prog.ProgressTo(.1, 250, Easing.Linear);
               

            try
            {



                List<ClassNews> rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = ClassURI.RusAll, Istochnik = "Lenta.ru" }, 10)));
                ViewModel.ListNews.Clear();

                if (rSSFeedItems.Count != 0)
                {

                    foreach (var v in rSSFeedItems)
                    {
                        v.ButShow = true;
                        ViewModel.ListNewsRus.Add(v);


                    }
                }
                rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vedomosti.ru/rss/issue", Istochnik = "Vedomosti.ru" }, 10)));
                int poz = 0;
                if (rSSFeedItems.Count != 0)
                {
                    foreach (var v in rSSFeedItems)
                    {
                        v.ButShow = true;
                        if (ViewModel.ListNewsRus.Count > poz * 2 + 1)
                        {
                            ViewModel.ListNewsRus.Insert(poz * 2 + 1, v);
                        }
                        else
                        {
                            ViewModel.ListNewsRus.Add(v);
                        }


                        poz++;

                    }
                }
                if (ViewModel.ListNewsRus.Count == 0)
                {
                    ViewModel.ListNewsRus.Add(new ClassNews() { Title = "Новостей по данной теме нет", Description = "Потяните вниз по списку данных что бы обновить.", ButShow = false, FigShow = false });


                }



            }
            catch (Exception)
            {

            }


        }

        public async Task zagruzka1World()
        {

            try
            {


                List<ClassNews> rSSFeedItems  = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = ClassURI.WrldAll, Istochnik = "Lenta.ru" }, 10)));
                ViewModel.ListNewsWord.Clear();
                if (rSSFeedItems.Count != 0)
                {

                    foreach (var v in rSSFeedItems)
                    {
                        ViewModel.ListNewsWord.Add(v);
                    }
                }
                rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vesti.ru/vesti.rss", Istochnik = "Vesti.ru" },10)));
                    int poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {
                            if (v.Category == "В мире")
                            {
                                if (ViewModel.ListNewsWord.Count > poz * 2 + 1)
                                {
                                ViewModel.ListNewsWord.Insert(poz * 2 + 1, v);
                                }
                                else
                                {
                                ViewModel.ListNewsWord.Add(v);
                                }
                                poz++;
                            }
                        }
                    }
                    rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://news.rambler.ru/rss/world/", Istochnik = "rambler.ru" }, 10)));
                    poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {

                            if (ViewModel.ListNewsWord.Count > poz * 2 + 1)
                            {
                            ViewModel.ListNewsWord.Insert(poz * 2 + 1, v);
                            }
                            else
                            {
                            ViewModel.ListNewsWord.Add(v);
                            }
                            poz++;

                        }
                    }

                    if (ViewModel.ListNewsWord.Count == 0)
                    {
                    ViewModel.ListNewsWord.Add(new ClassNews() { Title = "Новостей по данной теме нет", Description = "Потяните вниз по списку данных что бы обновить.", ButShow = false, FigShow = false });
                    }
                }
           

            
            catch (Exception ex)
            {

            }
            finally
            {
                //   await prog.ProgressTo(1, 250, Easing.Linear);
            }
            // RSSFeedItem.h = 0.75 * phonesList.Width;
            //   await prog.ProgressTo(1, 250, Easing.Linear);
            // await prog.ProgressTo(0, 250, Easing.Linear);
        }
        public async Task zagruzka1Econom()
        {

            try
            {
                

                
                    List<ClassNews> rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = ClassURI.EconomicaAll, Istochnik = "Lenta.ru" }, 10)));
                ViewModel.ListNewsiconom.Clear();
                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {
                            v.ButShow = true;
                        ViewModel.ListNewsiconom.Add(v);
                        }
                    }
                    rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vesti.ru/vesti.rss", Istochnik = "Vesti.ru" }, 10)));
                    int poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {



                        foreach (var v in rSSFeedItems)
                        {
                            if (v.Category == "Экономика" || v.Category == "Бизнес" || v.Category == "Финансы")
                            {
                                v.ButShow = true;
                                if (ViewModel.ListNewsiconom.Count > poz * 2 + 1)
                                {
                                ViewModel.ListNewsiconom.Insert(poz * 2 + 1, v);
                                }
                                else
                                {
                                ViewModel.ListNewsiconom.Add(v);
                                }
                                poz++;
                            }
                        }
                    }

                    rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vedomosti.ru/rss/articles", Istochnik = "Vedomosti.ru" },10)));
                    poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {



                        foreach (var v in rSSFeedItems)
                        {
                            if (v.Category == "Экономика" || v.Category == "Бизнес" || v.Category == "Финансы")
                            {
                                v.ButShow = true;
                                if (ViewModel.ListNewsiconom.Count > poz * 2 + 1)
                                {
                                ViewModel.ListNewsiconom.Insert(poz * 2 + 1, v);
                                }
                                else
                                {
                                ViewModel.ListNewsiconom.Add(v);
                                }
                                poz++;
                            }
                        }
                    }
                    if (ViewModel.ListNewsiconom.Count == 0)
                    {
                    ViewModel.ListNewsiconom.Add(new ClassNews() { Title = "Новостей по данной теме нет", Description = "Потяните вниз по списку данных что бы обновить.", ButShow = false, FigShow = false });
                    }
                
            
            }
            catch
            {

            }

        }
        public async Task zagruzkaSport()
        {

            try
            {
               

                
                    List<ClassNews> rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = ClassURI.SportAll, Istochnik = "Lenta.ru" },10)));
                ViewModel.ListNewsSport.Clear();
                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {
                        ViewModel.ListNewsSport.Add(v);
                        }
                    }
                    rSSFeedItems = await Task.Run(() => (classComand.zagruzka1(new ClassIstochnik() { Urr = @"https://www.vesti.ru/vesti.rss", Istochnik = "Vesti.ru" }, 10)));
                    int poz = 0;
                    if (rSSFeedItems.Count != 0)
                    {

                        foreach (var v in rSSFeedItems)
                        {
                            if (v.Category == "Спорт")
                            {
                                if (ViewModel.ListNewsSport.Count > poz * 2 + 1)
                                {
                                ViewModel.ListNewsSport.Insert(poz * 2 + 1, v);
                                }
                                else
                                {
                                ViewModel.ListNewsSport.Add(v);
                                }
                                poz++;
                            }

                        }
                    }
                    if (ViewModel.ListNewsSport.Count == 0)
                    {
                    ViewModel.ListNewsSport.Add(new ClassNews() { Title = "Новостей по данной теме нет", Description = "Потяните вниз по списку данных что бы обновить.", ButShow = false, FigShow = false });
                    }
             
            }
            catch
            {

            }

        }
        private async void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot GridViewNews = sender as Pivot;
            int classNews = (int)GridViewNews.SelectedIndex;
            switch (classNews)
            {
                case 0:
                  await zagruzka1();
                    break;

                case 1:
                    await zagruzka1RusAll();
                    break;
                case 2:
                    await zagruzka1World();
                    break;
                case 3:
                    await zagruzka1Econom();
                    break;
                case 4:
                    await zagruzkaSport();
                    break;

            }
        
        }
    }
}
