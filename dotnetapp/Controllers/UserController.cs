using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        private readonly ILogger<UserController> logger;
        public UserController(IUser user, ILogger<UserController> logger)
        {
            this.user = user;
            this.logger = logger;
        }
        [HttpPost]
        [Route("addUser")]
        public ResponseModel addUser(UserModel data)
        {
            try
            {
                var res= user.addUser(data);
                if (res == "User created successfully")
                {
                    logger.LogInformation("user created");
                    ResponseModel response = new ResponseModel();
                    response.Message = "User created successfully";

                    response.Status = true;
                    response.ErrorMessage = null;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "User not created successfully";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not created");
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at useradd");
                return response;
                
            }
            
        }
        [HttpDelete]
        [Route("deleteUser")]
        public ResponseModel deleteUser(string UserID)
        {
            try
            {

               var res= user.deleteUser(UserID);
                if (res == "user deleted")
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "user deleted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user deleted");
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "user not deleted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not deleted");
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at userdeleted");
                return response;

            }
            
        }
        [HttpPut]
        [Route("editUser")]
        public ResponseModel editUser(UserModel data)
        {
            try
            {
                var res= user.editUser(data);
                if (res == "User Editted")
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "User Editted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user edited");
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "User not Editted";

                    response.Status = true;
                    response.ErrorMessage = null;
                    logger.LogInformation("user not edited");
                    return response;
                }
            }
            catch (Exception e)
            {

                ResponseModel response = new ResponseModel();
                response.Message = "error";

                response.Status = true;
                response.ErrorMessage = e.Message;
                logger.LogError($"{e.Message} at useredited");
                return response;
            }
             
        }
        [HttpGet]
        [Route("getUser")]
        public UserModel getUser(string UserID)
            
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
