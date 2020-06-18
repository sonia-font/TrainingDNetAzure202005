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
    public class VideosController : ControllerBase
    {
        #region Members & Properties

        private readonly IVideoService _videoService;

        #endregion

        #region Constructors

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Retrieves all videos.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _videoService.GetVideos();
            return Ok(list);            
        }

        /// <summary>
        /// Retrieves a specific video.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var video = await _videoService.GetVideo(id);
            return Ok(video);
        }

        /// <summary>
        /// Adds a specific studio.
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "name": "string",
        ///             "duration": 0,
        ///             "directedBy": "string",
        ///             "genre": "string",
        ///             "studioId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns true</response>
        /// <response code="400">Error</response> 
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] VideoDto dto)
        {
            await _videoService.AddVideo(dto);
            return Ok(true);
        }

        /// <summary>
        /// Deletes a specific studio.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _videoService.RemoveVideo(id);
            return Ok(true);          
        }

        #endregion
    }
}