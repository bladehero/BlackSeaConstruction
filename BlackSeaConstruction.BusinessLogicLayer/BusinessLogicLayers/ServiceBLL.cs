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
                    vm.Images = _serviceImages.GetServiceImageByServiceId(m.Id).Select(z => z.Image);
                    vm.ServiceType = _serviceTypes.FindById(m.TypeId)?.TypeName;
                });
                cfg.CreateMap<ServiceVM, Service>();
                cfg.CreateMap<ServiceType, ServiceTypeVM>().AfterMap((m, vm) =>
                {
                    vm.Services = _services.GetServicesByTypeId(m.Id).Select(x => new ServiceVM
                    {
                        Id = x.Id,
                        Description = x.Description,
                        ServiceName = x.ServiceName,
                        ServiceType = vm.TypeName,
                        Images = _serviceImages.GetServiceImageByServiceId(x.Id).Select(z => z.Image)
                    }).ToList();
                });
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
            var serviceTypeVMs = Map<IEnumerable<ServiceType>, IEnumerable<ServiceTypeVM>>(serviceTypes);
            return serviceTypeVMs;
        }
    }
}
