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
    public class StudiosControllerTests
    {
        #region GetAll_Tests

        /// <summary>
        /// This UnitTest tests that the GetAll Studios method return a list of items
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllStudios_Succesful()
        {
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudios()).ReturnsAsync(GetTestListStudioDto());
            var studiosController = new StudiosController(mockService.Object);
            var result = await studiosController.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.Value != null);
        }

        /// <summary>
        /// This unit test verifies that method throw a error when there is no items in the collection result.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllStudios_ThrowException()
        {
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudios()).ThrowsAsync(new Exception("Error Loading Studios List"));
            var studiosController = new StudiosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<Exception>(() => studiosController.GetAll());
            Assert.Equal("Error Loading Studios List", ex.Message);
        }

        #endregion

        #region Get_Tests
        /// <summary>
        /// This UnitTest tests that the GetByIdMethod returns a valid studio item
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetStudio_ValidId_RetrievedObjectIsStudioDto()
        {
            Guid id = new Guid();
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudio(It.IsAny<Guid>())).ReturnsAsync(GetTestStudioDto(id));
            var studiosController = new StudiosController(mockService.Object);
            var result = await studiosController.Get(id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<StudioDto>(okResult.Value);
        }

        [Fact]
        public async Task GetStudio_ValidId_RetrievedStudioHasSameId()
        {
            Guid testId = new Guid();
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudio(It.IsAny<Guid>())).ReturnsAsync(GetTestStudioDto(testId));
            var studiosController = new StudiosController(mockService.Object);
            var result = await studiosController.Get(testId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            StudioDto studio = (StudioDto)okResult.Value;
            Assert.Equal(studio.Id, testId);
        }

        [Fact]
        public async Task GetStudio_WithEmptyId_ThrowsArgumentException()
        {
            Guid id = Guid.Empty;
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudio(It.IsAny<Guid>())).ThrowsAsync(new ArgumentException("Error Retrieving Studio, Id can not be empty"));
            var videosController = new StudiosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => videosController.Get(id));
            Assert.Equal("Error Retrieving Studio, Id can not be empty", ex.Message);
        }

        [Fact]
        public async Task GetStudio_WithNullId_ThrowsNullArgumentException()
        {
            string errorMessage = "Error loading studios list, Id can not be null";
            var mockService = new Mock<IStudioService>();
            mockService.Setup(servicio => servicio.GetStudio(It.IsAny<Guid>())).ThrowsAsync(new ArgumentNullException(errorMessage, new InvalidOperationException()));
            var studiosController = new StudiosController(mockService.Object);
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => studiosController.Get(new Guid()));
            Assert.Equal(errorMessage, ex.Message);
        }


        #endregion

        #region Add_Tests

        [Fact]
        public async Task Add_Studio_Succesful()
        {
            var mockService = new Mock<IStudioService>();
            mockService.Setup(service => service.AddStudio(It.IsAny<StudioDto>())).Returns(Task.CompletedTask).Verifiable();
            var studioController = new StudiosController(mockService.Object);
            StudioDto dummy = new StudioDto();
            var result = await studioController.Add(dummy);
            var iActionResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)iActionResult.Value);
        }

        [Fact]
        public async Task Add_EmptyStudio_ThrowArgumentException()
        {
            string errorMessage = "Error ocurred adding studio, the studio data cant be empty";
            var mockService = new Mock<IStudioService>();
            mockService.Setup(service => service.AddStudio(It.IsAny<StudioDto>())).Returns(Task.FromException(new ArgumentException(errorMessage)));
            var studioController = new StudiosController(mockService.Object);
            StudioDto dummy = new StudioDto();
            Exception exception = await Assert.ThrowsAsync<ArgumentException>(() => studioController.Add(dummy));
            Assert.Equal(errorMessage, exception.Message);
        }

        [Fact]
        public async Task Add_NullStudio_ThrowNullArgumentException()
        {
            string errorMessage = "Error ocurred adding Studio, the video data cant be empty";
            var mockService = new Mock<IStudioService>();
            mockService.Setup(service => service.AddStudio(It.IsAny<StudioDto>())).Returns(Task.FromException(new ArgumentNullException(errorMessage, new InvalidOperationException())));
            var studioController = new StudiosController(mockService.Object);
            Exception exception = await Assert.ThrowsAsync<ArgumentNullException>(() => studioController.Add(null));
            Assert.Equal(exception.Message, errorMessage);
        }

        #endregion

        #region Remove_Tests

        [Fact]
        public async Task Remove_Studio_Succesful()
        {
            StudioDto dummy = new StudioDto();
            var mockService = new Mock<IStudioService>();
            mockService.Setup(service => service.RemoveStudio(It.IsAny<Guid>())).Returns(Task.CompletedTask).Verifiable();
            var studioController = new StudiosController(mockService.Object);
            var result = await studioController.Remove(dummy.Id);
            var iActionResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)iActionResult.Value);
        }
        
        [Fact]
        public async Task Remove_StudioWithEmptyId_ThrowArgumentException()
        {
            string errorMessage = "Error Ocurred removing studio, The Id of the studio can not be empty.";
            var mockService = new Mock<IStudioService>();
            mockService.Setup(service => service.RemoveStudio(It.IsAny<Guid>())).Returns(Task.FromException(new ArgumentException(errorMessage)));
            var studioController = new StudiosController(mockService.Object);
            StudioDto dummy = new StudioDto();
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => studioController.Remove(dummy.Id));
            Assert.Equal(errorMessage, exception.Message);
        }

        #endregion

        #region TestMethods

        private StudioDto GetTestStudioDto(Guid id)
        {
            StudioDto studioTest = new StudioDto();
            studioTest.Id = id;
            return studioTest;
        }

        private List<StudioDto> GetTestListStudioDto()
        {
            List<StudioDto> studioListTest = new List<StudioDto>();
            StudioDto studioTest1 = new StudioDto();
            StudioDto studioTest2 = new StudioDto();
            StudioDto studioTest3 = new StudioDto();
            studioListTest.Add(studioTest1);
            studioListTest.Add(studioTest2);
            studioListTest.Add(studioTest3);

            return studioListTest;
        }

        #endregion

    }
}
