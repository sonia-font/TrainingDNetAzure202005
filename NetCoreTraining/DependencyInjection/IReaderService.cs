using System;

namespace DependencyInjection
{
    public interface IReaderService
    {
        void ReadMessage(Guid processId);
    }
}