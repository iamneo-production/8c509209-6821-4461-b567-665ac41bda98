using dotnetapp.Interface;
using dotnetapp.Models;

namespace dotnetapp.Core
{
    public class ExceptionHandling : IExceptionHandling
    {
        public ResponseModel ExceptionHandle(string e)
        {
            ResponseModel response = new ResponseModel();

            response.Message = "error";
            response.Status=false;
            response.ErrorMessage=e;
            return response;
        
    }
    }

}

