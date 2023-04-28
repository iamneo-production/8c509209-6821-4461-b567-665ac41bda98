
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : Controller
    {
        private readonly IAuth authcore;
        private readonly IUser userCore;
        private readonly ILogger<AuthController> logger;
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
                    
                    var response =  userCore.addUser(userModel);
                    
                    ResponseModel Response = new ResponseModel();
                    Response.Message = "registered user";
                    Response.Status = true;
                    logger.LogInformation("USER CREATED");
                    return Task.FromResult(Response);
                }
                else
                {
                   
                    ResponseModel response = new ResponseModel();
                    response.Message = "Send proper Request with proper input";
                    response.Status = true;
                    logger.LogInformation("unable to USER CREATED");
                    return Task.FromResult(response);
                    
                }

            }
            catch (System.Exception ex)
            {

                ResponseModel response = new ResponseModel();
                response.ErrorMessage = "Send proper Request with proper input";
                response.Status = false;
                response.ErrorMessage = ex.Message;
                logger.LogError($"{ex.Message} at register user");
                return Task.FromResult(response);
               
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Token")]

        public ResponseModel GenerateToken([FromBody] LoginModel loginModel)
        {
            ResponseModel response = null;
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
            catch (System.Exception ex)
            {

                response = new ResponseModel();
                response.Message = "Opps !";
                response.ErrorMessage = ex.Message;
                response.Status = false;
                logger.LogError($"{ex.Message} at TOKEN GENERATION");
                return response;
            }
        }
        
       

    }
}