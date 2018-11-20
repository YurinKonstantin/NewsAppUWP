using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace NewsAppUWP
{
   public class ClassViewModeNews
    {
        private ObservableCollection<ClassNews> listNews = new ObservableCollection<ClassNews>();
        public ObservableCollection<ClassNews> ListNews { get { return this.listNews; } }
        private ObservableCollection<ClassNews> listNewsRus = new ObservableCollection<ClassNews>();
        public ObservableCollection<ClassNews> ListNewsRus { get { return this.listNewsRus; } }
        private ObservableCollection<ClassNews> listNewsWord = new ObservableCollection<ClassNews>();
        public ObservableCollection<ClassNews> ListNewsWord { get { return this.listNewsWord; } }
        private ObservableCollection<ClassNews> listNewsiconom = new ObservableCollection<ClassNews>();
        public ObservableCollection<ClassNews> ListNewsiconom { get { return this.listNewsiconom; } }
        private ObservableCollection<ClassNews> listNewsSport = new ObservableCollection<ClassNews>();
        public ObservableCollection<ClassNews> ListNewsSport { get { return this.listNewsSport; } }
        public void AddListNews(ClassNews classNews)
        {
            
              
                    ListNews.Add(classNews);

            
           
        }
    }
}
