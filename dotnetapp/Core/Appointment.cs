using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Linq;

namespace dotnetapp.Core
{
    public class Appointment : IAppointment
    {
        private readonly PrinterServiceContext serviceContext;
        public Appointment(PrinterServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }
        public bool deleteAppointment(int ProductID)
        {
            try
            {
                var res = serviceContext.productModels.Find(ProductID);
                if (res != null)
                {
                    serviceContext.Remove(res);
                    serviceContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool EditAppointment(ProductModel data)
        {
            try
            {


                var sc = serviceContext.productModels.Find(data.Id);
                if (sc != null)
                {
                    //var a = serviceContext.userModels.Find(data.UserId);
                    //if (a == null)
                    //{
                    //    return false;
                    //}

                    sc.ProductName = data.ProductName;
                    sc.ProductModelNo = data.ProductModelNo;
                    sc.DateOfPurchase = data.DateOfPurchase;
                    sc.ContactNumber = data.ContactNumber;
                    sc.ProblemDescription = data.ProblemDescription;
                    sc.AvailableSlots = data.AvailableSlots;
                    sc.UserId = data.UserId;



                    serviceContext.productModels.Update(sc);
                    serviceContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }


        }

        public IQueryable<ProductModel> getAppointment()
        {
            try
            {
                return serviceContext.productModels.AsQueryable();

            }
            catch
            {
                throw;
            }

        }

        public string saveAppointment(ProductModel data)
        {
            try
            {
                
                serviceContext.productModels.Add(data);
                serviceContext.SaveChanges();
                return "created";

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
