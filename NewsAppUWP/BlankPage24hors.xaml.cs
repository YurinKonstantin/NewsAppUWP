using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            this.ViewModel = new ClassViewModeNews();
           classComand = new ClassComand();
            Start();


        }
        ClassComand classComand;
        List<ClassNews> classNews;
        public async void Start()
        {
          
           
                ViewModel.AddListNews(await classComand.zagruzka1(@"https://lenta.ru/rss/last24/", 10));
            
        }
        public ClassViewModeNews ViewModel { get; set; }
       
    }
}
