
using GetTicketMVC.ApiServices;
using GetTicketMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GetTicketMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IHttpApiService, HttpApiService>();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<CityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CitiesConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.MapAreaControllerRoute(
                name: "adminPanelDefault",
                areaName: "AdminPanel",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
            app.Run(); 
        }
    }
}