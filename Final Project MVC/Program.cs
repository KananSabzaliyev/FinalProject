using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using DataAccess.SqlDbContext;
using Entities.Membership;
using Microsoft.AspNetCore.Identity;

namespace Final_Project_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddScoped<ICarDal, CarDal>();
            builder.Services.AddScoped<ICarService, CarManager>();

            builder.Services.AddScoped<ICarBodyDal, CarBodyDal>();
            builder.Services.AddScoped<ICarbodyService, CarBodyManager>();

            builder.Services.AddScoped<IBrandDal, BrandDal>();
            builder.Services.AddScoped<IBrandservice, BrandManager>();

            builder.Services.AddScoped<IGearDal, GearDal>();
            builder.Services.AddScoped<IGearservice, GearManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}