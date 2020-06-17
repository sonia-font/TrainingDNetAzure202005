using System;
using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class FileReaderService : IReaderService
    {
        private readonly ILogger<MemoryReaderService> _logger;

        public FileReaderService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MemoryReaderService>();
        }

        public void ReadMessage(Guid processId)
        {
            _logger.LogInformation($"Reading message from FileReaderService for the ProcessId: [{processId}] ");
        }
    }
}