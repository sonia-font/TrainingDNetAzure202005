using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Returns all studios
        /// </summary>
        /// <returns>Studio collection</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _studioService.GetStudios();

            return Ok(list);
        }

        /// <summary>
        /// Returns one studio given it id
        /// </summary>
        /// <param name="id">studio id in a GUID format</param>
        /// <returns>Studio with all its data</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Studio = await _studioService.GetStudio(id);

            return Ok(Studio);
        }
        /// <summary>
        /// Add a new Studio
        /// </summary>
        /// <param name="dto">studio object to be added</param>
        /// <returns>ok if operation successful</returns>
        /// <response code="200">If operation successfull</response>
        /// <response code="400">If object is null</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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