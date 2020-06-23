using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Application.Dto;

namespace Training.Application.Services
{
    public interface IStudioService
    {
        Task AddStudio(StudioDto dto);
        Task RemoveStudio(Guid id);
        Task<IEnumerable<StudioDto>> GetStudios();
        Task<StudioDto> GetStudio(Guid id);
    }
}