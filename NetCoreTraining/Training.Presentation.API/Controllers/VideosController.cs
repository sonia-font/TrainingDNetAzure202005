using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<VideosController> _logger;

        #endregion

        #region Constructors

        public VideosController(IVideoService videoService, ILogger<VideosController> logger)
        {
            _videoService = videoService;
            _logger = logger;
        }

        #endregion

        #region Actions

        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("----------VideosController GetAll----------");
            Trace.WriteLine("---------Trace VideosController GetAll----------");
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
            _logger.LogInformation("--------VideosCongroller Add---------");
            await _videoService.AddVideo(dto);
            return Ok(true);
        }

        [EnableCors("MyPolicy")]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] VideoDto dto)
        {
            _logger.LogInformation("--------VideosCongroller Update---------");
            await _videoService.UpdateVideo(dto);
            return Ok(true);
        }

        [EnableCors("MyPolicy")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            _logger.LogInformation("--------VideosCongroller Delete---------");
            await _videoService.RemoveVideo(id);
            return Ok(true);          
        }

        #endregion
    }
}