using BlackSeaConstruction.BusinessLogicLayer.ViewModels.News;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Models
{
    public class IndexVM
    {
        public IEnumerable<NewsVM> News { get; set; }
    }
}
