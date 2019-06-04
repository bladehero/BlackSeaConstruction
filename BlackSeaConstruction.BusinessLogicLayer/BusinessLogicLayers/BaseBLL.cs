using AutoMapper;
using System;
using System.Collections.Generic;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public abstract class BaseBLL
    {
        protected IMapper Mapper { get; set; }

        public D Map<S, D>(S source) => Mapper.Map<S, D>(source);
    }
}
