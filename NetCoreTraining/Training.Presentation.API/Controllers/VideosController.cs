using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Training.Application.Dto;
using Training.Application.Services;

namespace Training.Presentation.API.Controllers
{
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

        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _videoService.GetVideos();
            return Ok(list);            
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var video = await _videoService.GetVideo(id);
            return Ok(video);
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] VideoDto dto)
        {
            await _videoService.AddVideo(dto);
            return Ok(true);
        }

        [EnableCors("MyPolicy")]
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