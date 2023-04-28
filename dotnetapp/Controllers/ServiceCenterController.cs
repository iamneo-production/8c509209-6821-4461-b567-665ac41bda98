using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Collections.Generic;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCenterController : ControllerBase
    {
        private readonly IServiceCenter ISCenter;
        private readonly ILogger<ServiceCenterController> logger;
        public ServiceCenterController(IServiceCenter ISCenter, ILogger<ServiceCenterController> logger)
        {
            this.ISCenter = ISCenter;
            this.logger = logger;   
        }

        [HttpGet]
        [Route("viewServiceCenter")]
        public  ResponseModel viewServiceCenter()
        {
            try
            {
                var res = ISCenter.viewServiceCenter();
                logger.LogInformation("SERVICE VIEWED");
                if (res != null)
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "found";
                    response.Response = res;
                    response.Status = true;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Not Found!";
                    response.Status = false;
                    return response;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message} at viewservice");
                ResponseModel response = new ResponseModel();
                response.ErrorMessage = e.Message;
                response.Status = false;
                return response;
            }
            
        }

        [HttpPost]
        [Route("addServiceCenter")]
        public ResponseModel addServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                var res = ISCenter.addServiceCenter(serviceModel);
                if (res == "Service center added")
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE Added");
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "row not Created";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not Added");
                    return response;

                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at addservice");
                return response;
                
            }
           
        }

        [HttpPut]
        [Route("editServiceCenter")]
        public ResponseModel editServiceCenter(ServiceCenterModel serviceModel)
        {
            try
            {
                var res = ISCenter.editServiceCenter(serviceModel);
                if (res == "Service center updated")
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE editted");
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Service center not updated";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not editted");
                    return response;
                }
            }
            catch (Exception e)
            {

                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at editservice");
                return response;
            }
            
        }

        [HttpDelete]
        [Route("deleteServiceCenter/{serviceCenterID}")]
        public ResponseModel deleteServiceCenter(int serviceCenterID)
        {
           
                try
                {

                    var res = ISCenter.deleteServiceCenter(serviceCenterID);
                    if (res == "Service center deleted")
                    {
                        ResponseModel response = new ResponseModel();
                        response.Message = "Service center deleted";

                        response.Status = true;
                        response.ErrorMessage = null;
                    logger.LogInformation("SERVICE deleted");
                    return response;
                    }
                    else
                    {
                        ResponseModel response = new ResponseModel();
                        response.Message = "Service center not deleted";

                        response.Status = true;
                        response.ErrorMessage = null;
                    logger.LogInformation("SERVICE not deleted");
                    return response;
                    }
                }
                catch (Exception e)
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "error";

                    response.Status = true;
                    response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at editservice");
                return response;

                }
                
                
            
            
            
        }
    }
}
