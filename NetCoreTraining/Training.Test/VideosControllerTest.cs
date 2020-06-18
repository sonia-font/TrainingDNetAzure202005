using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.Application.Services;
using Xunit;
using Training.Presentation.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Training.Application.Dto;

namespace Training.Test
{
    public class VideosControllerTest
    {
        #region GetAll_Tests

        /// <summary>
        /// This UnitTest tests that the GetAll Videos method return a list of items
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllVideos_Succesful()
        {
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideos()).ReturnsAsync(GetTestListVideoDto());
            var videosController = new VideosController(mockService.Object);
            var result = await videosController.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.Value != null);
        }

        /// <summary>
        /// This unit test verifies that method throw a error when there is no items in the collection result.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllVideos_ThrowException()
        {
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideos()).ThrowsAsync(new Exception("Error Loading Videos List"));
            var videosController = new VideosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<Exception>(() => videosController.GetAll());
            Assert.Equal("Error Loading Videos List", ex.Message);
        }

        #endregion

        #region Get_Tests
        /// <summary>
        /// This UnitTest tests that the GetByIdMethod returns a valid video item
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetVideo_ValidId_RetrievedObjectIsVideoDto()
        {
            Guid id = new Guid();
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideo(It.IsAny<Guid>())).ReturnsAsync(GetTestVideoDto(id));
            var videosController = new VideosController(mockService.Object);
            var result = await videosController.Get(id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<VideoDto>(okResult.Value);
        }

        [Fact]
        public async Task GetVideo_ValidId_RetrievedVideoHasSameId()
        {
            Guid testId = new Guid();
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideo(It.IsAny<Guid>())).ReturnsAsync(GetTestVideoDto(testId));
            var videosController = new VideosController(mockService.Object);
            var result = await videosController.Get(testId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            VideoDto video = (VideoDto)okResult.Value;
            Assert.Equal(video.Id, testId);
        }

        [Fact]
        public async Task GetVideo_WithEmptyId_ThrowsArgumentException()
        {
            Guid id = Guid.Empty;
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideo(It.IsAny<Guid>())).ThrowsAsync(new ArgumentException("Error Retrieving Video, Id can not be empty"));
            var videosController = new VideosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => videosController.Get(id));
            Assert.Equal("Error Retrieving Video, Id can not be empty", ex.Message);
        }

        [Fact]
        public async Task GetVideo_WithNullId_ThrowsNullArgumentException()
        {
            string errorMessage = "Error loading videos list, Id can not be null";
            var mockService = new Mock<IVideoService>();
            mockService.Setup(servicio => servicio.GetVideo(It.IsAny<Guid>())).ThrowsAsync(new ArgumentNullException(errorMessage, new InvalidOperationException()));
            var videosController = new VideosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => videosController.Get(new Guid()));
            Assert.Equal(errorMessage, ex.Message);
        }


        #endregion

        #region Add_Tests

        [Fact]
        public async Task Add_Video_Succesful()
        {
            var mockService = new Mock<IVideoService>();
            mockService.Setup(service => service.AddVideo(It.IsAny<VideoDto>())).Returns(Task.CompletedTask).Verifiable();
            var videoController = new VideosController(mockService.Object);
            VideoDto dummy = new VideoDto();
            var result = await videoController.Add(dummy);
            var iActionResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)iActionResult.Value);
        }

        [Fact]
        public async Task Add_EmptyVideo_ThrowArgumentException()
        {
            string errorMessage = "Error ocurred adding video, the video data cant be empty";
            var mockService = new Mock<IVideoService>();
            mockService.Setup(service => service.AddVideo(It.IsAny<VideoDto>())).Returns(Task.FromException(new ArgumentException(errorMessage)));
            var videoController = new VideosController(mockService.Object);
            VideoDto dummy = new VideoDto();
            Exception exception = await Assert.ThrowsAsync<ArgumentException>(() => videoController.Add(dummy));
            Assert.Equal(errorMessage, exception.Message);
        }

        [Fact]
        public async Task Add_NullVideo_ThrowNullArgumentException()
        {
            string errorMessage = "Error ocurred adding video, the video data cant be empty";
            var mockService = new Mock<IVideoService>();
            mockService.Setup(service => service.AddVideo(It.IsAny<VideoDto>())).Returns(Task.FromException(new ArgumentNullException(errorMessage, new InvalidOperationException())));
            var videoController = new VideosController(mockService.Object);
            Exception exception = await Assert.ThrowsAsync<ArgumentNullException>(() => videoController.Add(null));
            Assert.Equal(exception.Message, errorMessage);
        }

        #endregion

        #region Remove_Tests

        [Fact]
        public async Task Remove_Video_Succesful()
        {
            VideoDto dummy = new VideoDto();
            var mockService = new Mock<IVideoService>();
            mockService.Setup(service => service.RemoveVideo(It.IsAny<Guid>())).Returns(Task.CompletedTask).Verifiable();
            var videoController = new VideosController(mockService.Object);
            var result = await videoController.Remove(dummy.Id);
            var iActionResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)iActionResult.Value);
        }
        
        [Fact]
        public async Task Remove_VideoWithEmptyId_ThrowArgumentException()
        {
            string errorMessage = "Error Ocurred removing video, The Id of the video can not be empty.";
            var mockService = new Mock<IVideoService>();
            mockService.Setup(service => service.RemoveVideo(It.IsAny<Guid>())).Returns(Task.FromException(new ArgumentException(errorMessage)));
            var videoController = new VideosController(mockService.Object);
            VideoDto dummy = new VideoDto();
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => videoController.Remove(dummy.Id));
            Assert.Equal(errorMessage, exception.Message);
        }

        #endregion

        #region TestMethods

        private VideoDto GetTestVideoDto(Guid id)
        {
            VideoDto videoTest = new VideoDto();
            videoTest.Id = id;
            return videoTest;
        }

        private List<VideoDto> GetTestListVideoDto()
        {
            List<VideoDto> videoListTest = new List<VideoDto>();
            VideoDto videoTest1 = new VideoDto();
            VideoDto videoTest2 = new VideoDto();
            VideoDto videoTest3 = new VideoDto();
            videoListTest.Add(videoTest1);
            videoListTest.Add(videoTest2);
            videoListTest.Add(videoTest3);

            return videoListTest;
        }

        #endregion

    }
}
