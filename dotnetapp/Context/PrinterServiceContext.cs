using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Context
{
    public class PrinterServiceContext : DbContext
    {
        public PrinterServiceContext(DbContextOptions<PrinterServiceContext> options) : base(options)
        { }
        public DbSet<AdminModel> adminModels { get; set; }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<LoginModel> loginModels { get; set; }
        public DbSet<ProductModel> productModels { get; set; }
        public DbSet<ServiceCenterModel> serviceModels { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AdminModel>().HasNoKey();
        //    modelBuilder.Entity<LoginModel>().HasNoKey();
        //}
    }
}
