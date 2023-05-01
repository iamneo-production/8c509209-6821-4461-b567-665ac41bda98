using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using dotnetapp.Core;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        private readonly ILogger<UserController> logger;
        private ResponseModel response = null;
        public UserController(IUser user, ILogger<UserController> logger)
        {
            this.user = user;
            this.logger = logger;
        }
        [HttpPost]
        [Route("addUser")]
        public async Task<ResponseModel> addUser(UserModel data)
        {
            try
            {
                var responses= user.addUser(data);
                if (responses == "User created successfully")
                {
                    logger.LogInformation("user created");
                     response = new ResponseModel();
                    response.Message = "User created successfully";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    response = new ResponseModel();
                    response.Message = "User not created successfully";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not created");
                    return response;
                }
            }
            catch (Exception e)
            {
                
                logger.LogError($"{e.Message} at useradd");
                return new ExceptionHandling().ExceptionHandle(e.Message);
                
            }
            
        }
        [HttpDelete]
        [Route("deleteUser")]
        public async  Task<ResponseModel> deleteUser(string UserID)
        {
            try
            {

               var responses= user.deleteUser(UserID);
                if (responses == "user deleted")
                {
                    response = new ResponseModel();
                    response.Message = "user deleted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user deleted");
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "user not deleted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not deleted");
                    return response;
                }
            }
            catch (Exception e)
            {
               
                logger.LogError($"{e.Message} at userdeleted");
                return new ExceptionHandling().ExceptionHandle(e.Message);

            }
            
        }
        [HttpPut]
        [Route("editUser")]
        public async Task<ResponseModel> editUser(UserModel data)
        {
            try
            {
                var res= user.editUser(data);
                if (res == "User Editted")
                {
                    response = new ResponseModel();
                    response.Message = "User Editted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user edited");
                    return response;
                }
                else
                {
                     response = new ResponseModel();
                    response.Message = "User not Editted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not edited");
                    return response;
                }
            }
            catch (Exception e)
            {

             
                logger.LogError($"{e.Message} at useredited");
                return  new ExceptionHandling().ExceptionHandle(e.Message); 
            }
             
        }
        [HttpGet]
        [Route("getUser")]
        public async Task<UserModel> getUser(string UserID)
            
        {
            try
            {

                logger.LogInformation("user by id");
                return user.getUser(UserID);
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message} at userbyid");
                throw;
            }
            
        }


    }
}
