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
        public void AddListNews(ClassNews classNews)
        {
            
              
                    ListNews.Add(classNews);

            
           
        }
    }
}
