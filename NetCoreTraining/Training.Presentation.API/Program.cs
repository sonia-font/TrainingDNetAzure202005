using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Formatting;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using Serilog.Formatting.Display;


namespace Training.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseSerilog((builderContext, configuration) => {
                configuration.WriteTo.File(new MessageTemplateTextFormatter("[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"), "logs/log.json",Serilog.Events.LogEventLevel.Information);
                configuration.MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning);
                configuration.MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Warning);
                configuration.WriteTo.Console();
            }).UseStartup<Startup>();
        }
    }

}