using AutoMapper;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.News;
using BlackSeaConstruction.DataAccessLayer.Dao;
using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class NewsBLL : BaseBLL
    {
        NewsDao _news;

        public int NewsCount(bool withDeleted = true) => _news.Count(withDeleted);

        public NewsBLL(IDbConnection connection)
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsVM>().ForMember("DatePublication", o =>
                {
                    o.MapFrom("DateCreated");
                });
                cfg.CreateMap<NewsVM, News>();
            }).CreateMapper();

            _news = new NewsDao(connection);
        }

        public NewsVM GetNewsById(int id)
        {
            var news = _news.FindById(id);
            var newsVM = Map<News, NewsVM>(news);
            return newsVM;
        }

        public IEnumerable<NewsVM> GetAllNews()
        {
            var news = _news.FindAll();
            var newsVM = Map<IEnumerable<News>, IEnumerable<NewsVM>>(news);
            return newsVM;
        }

        public IEnumerable<NewsVM> GetNews(int count = 7)
        {
            var news = _news.GetLastNews(count);
            var newsVM = Map<IEnumerable<News>, IEnumerable<NewsVM>>(news);
            return newsVM;
        }

        public IEnumerable<NewsVM> GetNews(int count, int skip = 0, bool withDeleted = true)
        {
            var news = _news.Take(count, skip, withDeleted);
            var newsVM = Map<IEnumerable<News>, IEnumerable<NewsVM>>(news);
            return newsVM;
        }

        public bool MergeNews(NewsVM newsVM)
        {
            var news = Map<NewsVM, News>(newsVM);
            return _news.Merge(news);
        }

        public bool DeleteNews(int id) => _news.Delete(id);
        public bool RestoreNews(int id) => _news.Restore(id);
        public bool DeleteOrRestoreNews(int id) => _news.FindById(id).IsDeleted ? _news.Restore(id) : _news.Delete(id);
    }
}
