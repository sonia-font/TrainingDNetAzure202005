using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Training.Presentation.API
{
	public class Program
    {
		public static void Main(string[] args)
		{
			try
			{
				ConfigureLogging();
				CreateWebHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{

				Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
				throw;
			}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureAppConfiguration(configuration =>
				{
					configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
					configuration.AddJsonFile(
						$"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
						optional: true);
				})
				.ConfigureLogging(logging =>
				logging.AddAzureWebAppDiagnostics()
				.AddConsole()
				.AddSerilog()
				);

		}

		private static void ConfigureLogging()
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile(
					$"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
					optional: true)
				.Build();

			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.WriteTo.Debug()
				.WriteTo.Console()
				.WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
				.Enrich.WithProperty("Environment", environment)
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
		}

		private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
		{
			return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
			{
				AutoRegisterTemplate = true,
				IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
			};
		}
	}

}