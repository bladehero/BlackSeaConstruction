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
                    vm.Images = _serviceImages.GetServiceImageByServiceId(m.Id).Select(x => new ServiceImageVM
                    {
                        Id = x.Id,
                        Image = x.Image,
                        IsDeleted = x.IsDeleted,
                        ServiceId = x.ServiceId
                    });
                    vm.ServiceType = _serviceTypes.FindById(m.TypeId)?.TypeName;
                });
                cfg.CreateMap<ServiceVM, Service>();
                cfg.CreateMap<ServiceType, ServiceTypeVM>();
                cfg.CreateMap<ServiceTypeVM, ServiceType>();
            }).CreateMapper();
        }

        #region Services
        public int ServicesCount(bool withDeleted = true) => _services.Count(withDeleted);

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

        public IEnumerable<ServiceVM> GetServices(int count = 10, int skip = 0, bool withDeleted = true)
        {
            var services = _services.Take(count, skip, withDeleted);
            var servicesVM = Map<IEnumerable<Service>, IEnumerable<ServiceVM>>(services);
            return servicesVM;
        }

        public IEnumerable<ServiceVM> GetAllServices()
        {
            var services = _services.FindAll();
            var servicesVM = Map<IEnumerable<Service>, IEnumerable<ServiceVM>>(services);
            return servicesVM;
        }

        public bool MergeService(ServiceVM serviceVM)
        {
            var service = Map<ServiceVM, Service>(serviceVM);
            var result = _services.Merge(service);
            serviceVM.Id = service.Id;
            return result;
        }

        public bool DeleteService(int id) => _services.Delete(id);
        public bool RestoreService(int id) => _services.Restore(id);
        public bool DeleteOrRestoreService(int id) => _services.FindById(id).IsDeleted ? _services.Restore(id) : _services.Delete(id);
        #endregion

        #region ServiceTypes
        public ServiceTypeVM GetServiceTypeById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var serviceType = _serviceTypes.FindById(id.Value);
            var serviceTypeVM = Map<ServiceType, ServiceTypeVM>(serviceType);
            return serviceTypeVM;
        }

        public IEnumerable<ServiceTypeVM> GetAllServiceTypes(bool withDeleted = false)
        {
            var serviceTypes = _serviceTypes.FindAll(withDeleted);
            var serviceTypeVMs = serviceTypes.Select(x => new ServiceTypeVM
            {
                Id = x.Id,
                TypeName = x.TypeName,
                Services = _services.GetServicesByTypeId(x.Id).Select(s => new ServiceVM
                {
                    Id = s.Id,
                    ServiceName = s.ServiceName
                }),
                IsDeleted = x.IsDeleted
            }).ToList();
            return serviceTypeVMs;
        }

        public bool MergeServiceType(ServiceTypeVM serviceTypeVM)
        {
            var serviceType = Map<ServiceTypeVM, ServiceType>(serviceTypeVM);
            var result = _serviceTypes.Merge(serviceType);
            serviceTypeVM.Id = serviceType.Id;
            return result;
        }

        public bool DeleteServiceType(int id) => _serviceTypes.Delete(id);
        public bool RestoreServiceType(int id) => _serviceTypes.Restore(id);
        public bool DeleteOrRestoreServiceType(int id) => _serviceTypes.FindById(id).IsDeleted ? _serviceTypes.Restore(id) : _serviceTypes.Delete(id);
        #endregion
    }
}
