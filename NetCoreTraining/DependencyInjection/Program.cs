using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Dependency Injection!!!");

            //->Setting up DI
            var serviceProvider = GetServiceContainer();
            //->Configure console logging
            var loggerFactory = serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //->Do the thing! (USE DI)
            var processManagerService = serviceProvider.GetService<IProcessManagerService>();
            processManagerService.LunchProcess();

            Console.Read();
        }

        private static ServiceProvider GetServiceContainer()
        {
            return new ServiceCollection()
                .AddLogging(
                builder =>
                {
                    builder.AddFilter("Netcore-Training", LogLevel.Debug);
                    builder.AddConsole();
                }
                )
                .AddSingleton<IReaderService, FileReaderService>()
                .AddSingleton<IProcessManagerService, MemoryProcessManagerService>()
                .BuildServiceProvider();
        }
    }
}