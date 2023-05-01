using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Collections.Generic;
using dotnetapp.Core;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCenterController : ControllerBase
    {
        private readonly IServiceCenter ISCenter;
        private readonly ILogger<ServiceCenterController> logger;
        private ResponseModel response = null;
        public ServiceCenterController(IServiceCenter ISCenter, ILogger<ServiceCenterController> logger)
        {
            this.ISCenter = ISCenter;
            this.logger = logger;   
        }

        [HttpGet]
        [Route("viewServiceCenter")]
        public  async Task<ResponseModel> viewServiceCenter()
        {
            try
            {
                var responses = ISCenter.viewServiceCenter();
                logger.LogInformation("SERVICE VIEWED");
                if (responses != null)
                {
                     response = new ResponseModel();
                    response.Message = "found";
                    response.Response = responses;
                    response.Status = true;
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "Not Found!";
                    response.Status = false;
                    return response;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message} at viewservice");
                
                return new ExceptionHandling().ExceptionHandle(e.Message);
            }
            
        }

        [HttpPost]
        [Route("addServiceCenter")]
        public async Task<ResponseModel> addServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                var responses = ISCenter.addServiceCenter(serviceModel);
                if (responses == "Service center added")
                {
                    response = new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE Added");
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "row not Created";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not Added");
                    return response;

                }
            }
            catch (Exception e)
            {
              
                logger.LogError($"{e.Message} at addservice");
                return new ExceptionHandling().ExceptionHandle(e.Message);
                
            }
           
        }

        [HttpPut]
        [Route("editServiceCenter")]
        public async Task<ResponseModel> editServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                var responses = ISCenter.editServiceCenter(serviceModel);
                if (responses == "Service center updated")
                {
                     response = new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE editted");
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "Service center not updated";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not editted");
                    return response;
                }
            }
            catch (Exception e)
            {

               
                logger.LogError($"{e.Message} at editservice");
                return new ExceptionHandling().ExceptionHandle(e.Message);
            }
            
        }

        [HttpDelete]
        [Route("deleteServiceCenter/{serviceCenterID}")]
        public async Task<ResponseModel> deleteServiceCenter(int serviceCenterID)
        {
           
                try
                {

                    var responses = ISCenter.deleteServiceCenter(serviceCenterID);
                    if (responses == "Service center deleted")
                    {
                        response = new ResponseModel();
                        response.Message = "Service center deleted";

                        response.Status = true;
                        response.ErrorMessage = null;
                    logger.LogInformation("SERVICE deleted");
                    return response;
                    }
                    else
                    {
                         response = new ResponseModel();
                        response.Message = "Service center not deleted";

                        response.Status = true;
                        response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not deleted");
                    return response;
                    }
                }
                catch (Exception e)
                {
                   
                logger.LogError($"{e.Message} at editservice");
                return new ExceptionHandling().ExceptionHandle(e.Message);

                }
                
                
            
            
            
        }
    }
}
