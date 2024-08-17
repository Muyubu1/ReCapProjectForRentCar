using Business.Abstarct;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            
            builder.Services.AddScoped<ICarService, CarManager>();
            builder.Services.AddScoped<ICarDal, EfCarDal>();
            builder.Services.AddScoped<ICustomerService, CustomerManager>();
            builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
            builder.Services.AddScoped<IRentalService, RentalManager>();
            builder.Services.AddScoped<IRentalDal, EfRentalDal>();
            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<IUserDal, EfUserDal>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Get}/{id?}");

            app.Run();
        }
    }
}
