using System;
using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class MemoryReaderService : IReaderService
    {
        private readonly ILogger<MemoryReaderService> _logger;

        public MemoryReaderService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MemoryReaderService>();
        }

        public void ReadMessage(Guid processId)
        {
            _logger.LogInformation($"Reading message from MemoryReaderService for the ProcessId: [{processId}] ");
        }
    }
}