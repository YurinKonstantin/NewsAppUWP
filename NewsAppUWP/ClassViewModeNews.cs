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
        public void AddListNews(List<ClassNews> classNews)
        {foreach(var news in classNews)
            {
             
                ListNews.Add(new ClassNews() { Title = news.Title, Description=news.Description, Enclosure=news.Enclosure});
            }
           
        }
    }
}
