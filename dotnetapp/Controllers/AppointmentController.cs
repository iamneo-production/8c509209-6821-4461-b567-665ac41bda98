﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Linq;
using dotnetapp.Core;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment app;
        private readonly ILogger<AppointmentController> logger;
        private  ResponseModel response = null;
        public AppointmentController(IAppointment app, ILogger<AppointmentController> logger)
        {
            this.app = app;
            this.logger = logger;   
        }
        
        [HttpGet]
        [Route("getAppointment")]
        public async Task< ResponseModel> getAppointment()
        {
            try
            {
                var responses =  app.getAppointment();
                logger.LogInformation("viewed");
                if (responses != null)
                {

                    response = new ResponseModel();
                    response.Response = responses;
                    response.Status = true;
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Response = null;
                    response.Message = "not found";
                    response.Status = false;
                    return response;
                }
               
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message} at register user");

               
                return new ExceptionHandling().ExceptionHandle(e.Message);
                
            }
           
        }

        [HttpPost]
        [Route("saveAppointment")]
        public async Task<ResponseModel> saveAppointment(ProductModel data)
        {
            try
            {
                var responses = app.saveAppointment(data);
                if(responses== "created")
                {
                    logger.LogInformation("appointment saved");
                     response= new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    logger.LogInformation("appointment not saved saved");
                     response= new ResponseModel();
                    response.Message = "row not Created";

                    response.Status = false;
                    response.ErrorMessage = null;
                    return response;
                }
            }
            catch (Exception e)
            {
              
                logger.LogError($"{e.Message} at appointment saved");
                return new ExceptionHandling().ExceptionHandle(e.Message);
                

                
            }
           
        }

        [HttpPut]
        [Route("EditAppointment")]
        public async Task<ResponseModel> EditAppointment(ProductModel data)
        {
            try
            {
                var responses = app.EditAppointment(data);
                if (responses == true)
                {
                    logger.LogInformation("appointment edited");
                     response = new ResponseModel();
                    response.Message = "Edited row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "row not edited";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("appointment not edited");
                    return response;
                }
            }
            catch (Exception e)
            {
                
                logger.LogError($"{e.Message} at appointmentedited");
                return   new ExceptionHandling().ExceptionHandle(e.Message); 
                
            }
           
        }

        [HttpDelete]
        [Route("deleteAppointment/{ProductID}")]
        public async Task<ResponseModel> deleteAppointment(int ProductID)
        {
            try
            {
                var responses = app.deleteAppointment(ProductID);
                if (responses == true)
                {
                    logger.LogInformation("appointment deleted");
                     response = new ResponseModel();
                    response.Message = "Deleted row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "row not edited";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("appointment not deleted");
                    return response;
                }
            }
            catch (Exception e)
            {
               
                logger.LogError($"{e.Message} at appointmentdeleted");
                return new ExceptionHandling().ExceptionHandle(e.Message);

            }
            
        }
    }
}
