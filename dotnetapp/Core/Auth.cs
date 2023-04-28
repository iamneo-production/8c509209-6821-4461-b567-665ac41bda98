using Microsoft.IdentityModel.Tokens;
using dotnetapp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;


using System.Net.Http;


using System.Xml.Linq;
using dotnetapp.Core.Interface;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System;
using dotnetapp.Context;

namespace dotnetapp.Core
{

    public class Auth : IAuth
        {
            private readonly PrinterServiceContext serviceContext;
            private readonly IConfiguration configuration;
            public Auth(PrinterServiceContext serviceContext, IConfiguration configuration)
            {
                this.serviceContext = serviceContext;
                this.configuration = configuration;
            }
            public ResponseModel GenerateToken(LoginModel loginModel)
            {
                try
                {
                    var userExists = serviceContext.userModels.FirstOrDefault(x => x.Email.ToLower() == loginModel.Email.ToLower() && x.Password.ToLower() == loginModel.Password.ToLower());
                    if (userExists != null)
                    {   var role= serviceContext.userModels.Where(x=>x.Email==loginModel.Email).Select(y=>y.UserRole).First();
                        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new[]
                            {
                        //new Claim(ClaimTypes.Email,loginModel.Email),
                        //new Claim("password",loginModel.Password),
                        new Claim("role",role)

                    };

                        var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

                        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);


                        ResponseModel responseModel = new ResponseModel();
                        responseModel.Message = generatedToken.ToString();
                        responseModel.Status = true;
                        return responseModel;
                    }
                    ResponseModel response = new ResponseModel();
                    response.ErrorMessage = $"No user found with username";
                    response.Status = true;
                    return response;
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

            public async Task<ResponseModel> RegisterUser(UserModel userModel)
            {
                ResponseModel responseModel = null;
                try
                {
                    var response = await serviceContext.userModels.AddAsync(userModel);
                    await serviceContext.SaveChangesAsync();
                    if (response != null)
                    {
                        responseModel = new ResponseModel();
                        responseModel.Message = "User registered";
                        responseModel.Status = true;
                        return responseModel;
                    }
                    else
                    {
                        responseModel = new ResponseModel();
                        responseModel.ErrorMessage = "User registration failled";
                        responseModel.Status = false;
                        return responseModel;
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
    }

