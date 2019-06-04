using System;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.News
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public DateTime DatePublication { get; set; }
    }
}
