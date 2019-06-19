using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.News;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class NewsIndexVM
    {
        public IEnumerable<NewsVM> News { get; set; }
        public PageVM Pages { get; set; }
        public bool WithDeleted { get; set; }
        public Dictionary<string,string> ServicesDictionary { get; set; }
        public Dictionary<string,string> WorksDictionary { get; set; }
    }
}
