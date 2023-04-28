using dotnetapp.Models;
using System.Collections.Generic;

namespace dotnetapp.Core.Interface
{
    public interface IServiceCenter
    {
        string addServiceCenter(ServiceCenterModel serviceModel);
        IEnumerable<ServiceCenterModel> viewServiceCenter();
        string editServiceCenter(ServiceCenterModel serviceModel);
        string deleteServiceCenter(int serviceCenterID);
    }
}
