using dotnetapp.Models;
using System.Threading.Tasks;

namespace dotnetapp.Core.Interface
{
    public interface IAuth
    {
        Task<ResponseModel> RegisterUser(UserModel userModel);
        ResponseModel GenerateToken(LoginModel loginModel);
    }
}
