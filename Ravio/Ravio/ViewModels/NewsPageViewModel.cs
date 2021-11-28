using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class NewsPageViewModel : BaseViewModel
    {
        public NewsPageViewModel()
        {
            Articles = new List<ArticleEntity>();

            GetNews();
        }

        private NewsRepository NewsRepository => DependencyService.Get<NewsRepository>();


        private List<ArticleEntity> articles;

        public List<ArticleEntity> Articles
        {
            get { return articles; }
            set { SetProperty(ref articles, value); }
        }

        private async void GetNews()
        {
            NewsEntity News = await NewsRepository.GetNews();
            Articles = new List<ArticleEntity>(News.Articles);
        }
    }
}
