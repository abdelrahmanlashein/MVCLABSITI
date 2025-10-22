using MVCLABSITI.Filters;
using MVCLABSITI.MiddleWares;
using Serilog;

namespace MVCLABSITI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region using Serilog;
            // Create Serilog logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/app-log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}"
                )
                .CreateLogger();
            #endregion


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews(op =>
            {
                op.Filters.Add<ExceptionHandleFilter>();
            });

            var app = builder.Build();        //custome middleware
            app.UseMiddleware<SerilogMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=getAll}/{id?}") //routing => 3 segments
                .WithStaticAssets();

            app.Run();
        }
    }
}
