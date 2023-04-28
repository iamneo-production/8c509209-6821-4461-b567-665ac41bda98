using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotnetapp.Core
{
    public class ServiceCenter : IServiceCenter
    {
        private readonly PrinterServiceContext serviceContext;
        public ServiceCenter(PrinterServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }


        public string addServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                serviceContext.serviceModels.Add(serviceModel);
                serviceContext.SaveChanges();
                return "Service center added";

            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<ServiceCenterModel> viewServiceCenter()
        {
            try
            {
                return serviceContext.serviceModels.ToList();
            }
            catch
            {
                throw;
            }

        }

        public string editServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                var sc = serviceContext.serviceModels.Find(serviceModel.ServiceCenterId);
                if (sc != null)
                {
                    sc.ServiceCenterName = serviceModel.ServiceCenterName;
                    sc.ServiceCenterImageUrl = serviceModel.ServiceCenterImageUrl;
                    sc.ServiceCenterPhone = serviceModel.ServiceCenterPhone;
                    sc.ServiceCenterMailId = serviceModel.ServiceCenterMailId;
                    sc.ServiceCenterAddress = serviceModel.ServiceCenterAddress;
                    sc.ServiceCenterDescription = serviceModel.ServiceCenterDescription;

                    serviceContext.serviceModels.Update(sc);
                    serviceContext.SaveChanges();
                    return "Service center updated";
                }
                return "Service center Not Updated";
            }
            catch
            {
                throw;
            }

        }

        public string deleteServiceCenter(int serviceCenterID)
        {
            try
            {
                var sc = serviceContext.serviceModels.Find(serviceCenterID);
                if (sc != null)
                {
                    serviceContext.Remove(sc);
                    serviceContext.SaveChanges();
                    return "Service center deleted";
                }
                return "Service center Not Deleted";
            }
            catch
            {
                throw;
            }
        }
    }
}
