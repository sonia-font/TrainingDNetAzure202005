using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Application.Dto;
using Training.Application.Services;

namespace Training.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        #region Members & Properties

        private readonly IStudioService _studioService;

        #endregion

        #region Constructors

        public StudiosController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _studioService.GetStudios();

            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Studio = await _studioService.GetStudio(id);

            return Ok(Studio);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] StudioDto dto)
        {
            await _studioService.AddStudio(dto);

            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _studioService.RemoveStudio(id);

            return Ok(true);
        }

        #endregion


    }
}