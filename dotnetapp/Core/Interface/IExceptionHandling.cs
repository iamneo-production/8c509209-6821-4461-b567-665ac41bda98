using dotnetapp.Models;

namespace dotnetapp.Interface
{
    public interface IExceptionHandling
    {
        ResponseModel ExceptionHandle(string e);

    }
}

