using AutoMapper;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services;
using BlackSeaConstruction.DataAccessLayer.Dao;
using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class ServiceBLL : BaseBLL
    {
        ServiceDao _services;
        ServiceImageDao _serviceImages;
        ServiceTypeDao _serviceTypes;

        public ServiceBLL(IDbConnection connection)
        {
            _services = new ServiceDao(connection);
            _serviceImages = new ServiceImageDao(connection);
            _serviceTypes = new ServiceTypeDao(connection);

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Service, ServiceVM>().AfterMap((m, vm) =>
                {
                    vm.Images = _serviceImages.GetServiceImageByServiceId(m.Id);
                    vm.ServiceType = _serviceTypes.FindById(m.TypeId)?.TypeName;
                });
                cfg.CreateMap<ServiceVM, Service>();
                cfg.CreateMap<ServiceType, ServiceTypeVM>();
                cfg.CreateMap<ServiceTypeVM, ServiceType>();
            }).CreateMapper();
        }

        public ServiceVM GetServiceById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var service = _services.FindById(id.Value);
            var serviceVM = Map<Service, ServiceVM>(service);
            return serviceVM;
        }

        public IEnumerable<ServiceTypeVM> GetAllServiceTypes()
        {
            var serviceTypes = _serviceTypes.FindAll();
            var serviceTypeVMs = serviceTypes.Select(x => new ServiceTypeVM
            {
                Id = x.Id,
                TypeName = x.TypeName,
                Services = _services.GetServicesByTypeId(x.Id).Select(s => new ServiceVM
                {
                    Id = s.Id,
                    ServiceName = s.ServiceName
                })
            }).ToList();
            return serviceTypeVMs;
        }
    }
}
