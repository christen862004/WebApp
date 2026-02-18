using Microsoft.EntityFrameworkCore;
using WebApp.Filtters;
using WebApp.Repository;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Services
            // Add services to the container.
            // buit in service already register
            // built in service need to register (optional service)
            //builder.Services.AddControllersWithViews(options => {
            //    options.Filters.Add(new HandelErrorAttribute());//Global attaibute
            //});

            builder.Services.AddControllersWithViews();
            //DbContextOptions , ITIContext register
            builder.Services.AddDbContext<ITIContext>(optionBuilder => { 
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            // Cutom Service 
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register
            builder.Services.AddScoped<ITestService, TestService>();//register
            #endregion

            var app = builder.Build();
            #region Inline MidldewareCustom
            //app.Use(async (ctx, next) => {
            //    await  ctx.Response.WriteAsync("1- Middleware 1\n");//<--1
            //    await next.Invoke();                                //<--2
            //    await ctx.Response.WriteAsync("1-1 Middleware 1-1\n");//<--7

            //});
            //app.Use(async (ctx, next) => {
            //    await ctx.Response.WriteAsync("2- Middleware 2\n");//<--3
            //    await next.Invoke();                               //<--4
            //    await ctx.Response.WriteAsync("2-2 Middleware 2-2\n");//<--6
            //});
            //app.Run(async(ctx) =>
            //{
            //    await ctx.Response.WriteAsync("3- Termiate\n");//<--5
            //});
            #endregion

            #region built in Middleware
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//path wwroot call next

            app.UseRouting();//Mapping Security (rout1 ,rout2 ,edfault)

            app.UseSession();//need to inject some service "built in service needd to registe"

            app.UseAuthorization();

            //Declare Route and execute mnaming convention rout
            //app.MapControllerRoute("Route1", "r1/{id:int:range(20,60)}/{name?}", new { controller = "Route", action = "Method1" });//
            //app.MapControllerRoute("Route1", "r1", new { controller = "Route", action = "Method1" });//
            app.MapControllerRoute("Route2", "r2", new { controller = "Route", action = "Method2" });
            //app.MapControllerRoute("Route2", "{contoller}/{action}", new { controller = "Route", action = "Method2" });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
