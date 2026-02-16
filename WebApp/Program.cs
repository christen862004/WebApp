using Microsoft.EntityFrameworkCore;
using WebApp.Repository;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // buit in service already register
            // built in service need to register (optional service)
            builder.Services.AddControllersWithViews();
            //DbContextOptions , ITIContext register
            builder.Services.AddDbContext<ITIContext>(optionBuilder => { 
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });


            // Cutom Service 
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register
            builder.Services.AddScoped<ITestService, TestService>();//register

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
