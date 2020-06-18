using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor;
using Training.Presentation.API.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions;
using Microsoft.Extensions.Logging;

namespace Training.Test
{
    public class ValuesControllerTests
    {
        /// <summary>
        /// This UnitTest tests that the get method of ValuesControllers return the defined value
        /// </summary>
        [Fact]
        public void TestGet()
        {
            var logger = new Moq.Mock<ILogger<ValuesController>>();
            var valuesController = new ValuesController(logger.Object);
            var result = valuesController.Get();
            Assert.Equal(result.Value, new string[] { "value1", "value2" });
        }

        /// <summary>
        /// This UnitTest tests that the Get Method of ValuesControllers return the correct output for the input value
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestGetById(int value)
        {
            int param = value;
            var logger = new Moq.Mock<ILogger<ValuesController>>();
            var valuesController = new ValuesController(logger.Object);
            var result = valuesController.Get(param);
            Assert.Equal(result.Value.ToString(), "value is " + param.ToString());
        }

    }
}
