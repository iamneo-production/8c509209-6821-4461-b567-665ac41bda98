using Microsoft.AspNetCore.Http;
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

    }
}
