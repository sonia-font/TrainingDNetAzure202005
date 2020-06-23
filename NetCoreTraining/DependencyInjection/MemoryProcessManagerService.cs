using System;

namespace DependencyInjection
{
    public class MemoryProcessManagerService : IProcessManagerService
    {
        private readonly IReaderService _readerService;

        public MemoryProcessManagerService(IReaderService readerService)
        {
            _readerService = readerService;
        }

        public void LunchProcess()
        {
            for (var i = 0; i < 5; i++)
            {
                _readerService.ReadMessage(Guid.NewGuid());
            }
        }
    }
}