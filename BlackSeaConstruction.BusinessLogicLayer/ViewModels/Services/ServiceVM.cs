﻿using System.Collections.Generic;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services
{
    public class ServiceVM
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string ServiceType { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}