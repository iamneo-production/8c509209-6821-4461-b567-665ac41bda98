
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System.Threading.Tasks;
using dotnetapp.Core;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : Controller
    {
        private readonly IAuth authcore;
        private readonly IUser userCore;
        private readonly ILogger<AuthController> logger;
        private ResponseModel response=null;
        //  private readonly ILogger<AuthController> logger1;
        public AuthController(IAuth authcore, IUser userCore, ILogger<AuthController> logger)
        {
            this.authcore = authcore;
            this.userCore = userCore;
            this.logger = logger;   
        }
        [HttpPost]
        [Route("Register")]
        public Task<ResponseModel> RegisterUser([FromBody] UserModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    
                    var responses =  userCore.addUser(userModel);
                    
                     response = new ResponseModel();
                    response.Message = "registered user";
                    response.Status = true;
                    logger.LogInformation("USER CREATED");
                    return Task.FromResult(response);
                }
                else
                {
                   
                     response = new ResponseModel();
                    response.Message = "Send proper Request with proper input";
                    response.Status = true;
                    logger.LogInformation("unable to USER CREATED");
                    return Task.FromResult(response);
                    
                }

            }
            catch (System.Exception e)
            {

               
                logger.LogError($"{e.Message} at register user");
                return Task.FromResult(new ExceptionHandling().ExceptionHandle(e.Message));
               
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Token")]

        public async Task<ResponseModel> GenerateToken([FromBody] LoginModel loginModel)
        {
            
            try
            {
                if (loginModel != null)
                {
                    if (!loginModel.Email.IsNullOrEmpty() && !loginModel.Password.IsNullOrEmpty())
                    {
                        logger.LogInformation("token created");
                        response = authcore.GenerateToken(loginModel);

                        return response;

                    }
                    else
                    {
                        logger.LogInformation("token not created");
                        response = new ResponseModel();
                        response.Message = "UserName and Password Required";
                        response.Status = true;
                        return response;
                    }
                }
                else
                {
                    logger.LogInformation("token not created");
                    response = new ResponseModel();
                    response.Message = "Send proper data in request";
                    response.Status = true;

                    return response;
                }
            }
            catch (System.Exception e)
            {

               
                logger.LogError($"{e.Message} at TOKEN GENERATION");
                return new ExceptionHandling().ExceptionHandle(e.Message);
            }
        }
        
       

    }
}