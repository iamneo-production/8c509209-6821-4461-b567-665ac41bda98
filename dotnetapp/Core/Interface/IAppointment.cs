using dotnetapp.Models;
using System.Linq;

namespace dotnetapp.Core.Interface
{
    public interface IAppointment
    {
        IQueryable<ProductModel> getAppointment();
        string saveAppointment(ProductModel data);
        bool EditAppointment(ProductModel data);
        bool deleteAppointment(int ProductID);
    }
}
