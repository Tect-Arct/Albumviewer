using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AlbumViewerBusiness; // ✅ Namespace where AlbumViewerContext is defined

namespace AlbumViewerNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();

            // ✅ Apply database migrations on startup
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<AlbumViewerContext>();
                    db.Database.Migrate();  // Ensures DB and tables are created
                    Console.WriteLine("✅ Database migration completed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Database migration failed: {ex.Message}");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                //.UseIIS()
                //.UseHttpSys(options =>
                //{
                //    options.Authentication.Schemes = AuthenticationSchemes.None;
                //    options.Authentication.AllowAnonymous = true;
                //    options.MaxConnections = 100;
                //    options.MaxRequestBodySize = 30000000;
                //    options.UrlPrefixes.Add("http://localhost:5002");
                //});

            return builder;
        }
    }
}
