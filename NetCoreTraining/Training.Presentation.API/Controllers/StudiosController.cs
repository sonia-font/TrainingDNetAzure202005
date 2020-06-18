using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Application.Dto;
using Training.Application.Services;

namespace Training.Presentation.API.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// Retrieves all studios.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _studioService.GetStudios();

            return Ok(list);
        }

        /// <summary>
        /// Retrieves a specific studio.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Studio = await _studioService.GetStudio(id);

            return Ok(Studio);
        }

        /// <summary>
        /// Adds a specific studio.
        /// </summary>
        /// /// /// <remarks>
        /// Sample request:
        ///
        ///     {      
        ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "name": "string"}
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns true</response>
        /// <response code="400">Error</response> 
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] StudioDto dto)
        {
            await _studioService.AddStudio(dto);

            return Ok(true);
        }

        /// <summary>
        /// Deletes a specific studio.
        /// </summary>
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