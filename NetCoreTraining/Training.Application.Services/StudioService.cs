using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Application.Dto;
using Training.Data.Domain;

namespace Training.Application.Services
{
    public class StudioService : IStudioService
    {
        #region Properties & Members

        private readonly IStudioRepository _studioRepository;

        #endregion

        #region Constructors

        public StudioService(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        #endregion

        #region IVideoService Implementation

        public async Task AddStudio(StudioDto dto)
        {
            var studioEntity = new Studio
            {
                Id = dto.Id,
                CreationDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Name = dto.Name
            };

            await _studioRepository.AddAsync(studioEntity);
        }

        public async Task<StudioDto> GetStudio(Guid id)
        {
            var studio = await _studioRepository.GetAsync(id);

            return new StudioDto
            {
                Id = studio.Id,
                Name = studio.Name,
            };
        }

        public async Task<IEnumerable<StudioDto>> GetStudios()
        {
            var studios = await _studioRepository.GetAllAsync();

            return studios.Select(x => new StudioDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task RemoveStudio(Guid id)
        {
            var studio = await _studioRepository.GetAsync(id);

            await _studioRepository.RemoveAsync(studio);
        }

        #endregion
    }
}