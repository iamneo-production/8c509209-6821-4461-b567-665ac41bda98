using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Linq;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment app;
        private readonly ILogger<AppointmentController> logger;
        public AppointmentController(IAppointment app, ILogger<AppointmentController> logger)
        {
            this.app = app;
            this.logger = logger;   
        }
        [HttpGet]
        [Route("getAppointment")]
        public ResponseModel getAppointment()
        {
            try
            {
                var res = app.getAppointment();
                logger.LogInformation("viewed");
                if (res != null)
                {

                    ResponseModel response = new ResponseModel();
                    response.Response = res;
                    response.Status = true;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Response = null;
                    response.Message = "not found";
                    response.Status = false;
                    return response;
                }
               
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message} at register user");

                ResponseModel response = new ResponseModel();
                response.ErrorMessage = e.Message;
                response.Status = false;
                return response;
                throw;
            }
           
        }

        [HttpPost]
        [Route("saveAppointment")]
        public ResponseModel saveAppointment(ProductModel data)
        {
            try
            {
                var res = app.saveAppointment(data);
                if(res== "created")
                {
                    logger.LogInformation("appointment saved");
                    ResponseModel response= new ResponseModel();
                    response.Message = "Created row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    logger.LogInformation("appointment not saved saved");
                    ResponseModel response= new ResponseModel();
                    response.Message = "row not Created";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at appointment saved");
                return response;

                
            }
           
        }

        [HttpPut]
        [Route("EditAppointment")]
        public ResponseModel EditAppointment(ProductModel data)
        {
            try
            {
                var res = app.EditAppointment(data);
                if (res == true)
                {
                    logger.LogInformation("appointment edited");
                    ResponseModel response = new ResponseModel();
                    response.Message = "Edited row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "row not edited";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("appointment not edited");
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at appointmentedited");
                return response;
                
            }
           
        }

        [HttpDelete]
        [Route("deleteAppointment/{ProductID}")]
        public ResponseModel deleteAppointment(int ProductID)
        {
            try
            {
                var res = app.deleteAppointment(ProductID);
                if (res == true)
                {
                    logger.LogInformation("appointment deleted");
                    ResponseModel response = new ResponseModel();
                    response.Message = "Edited row";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "row not edited";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("appointment not deleted");
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at appointmentdeleted");
                return response;

            }
            
        }
    }
}
