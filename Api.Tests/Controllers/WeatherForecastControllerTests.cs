using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController _controller;



        [TestMethod]
        public void Get_ReturnsWeatherForecasts()
        {
            // Arrange
            var logger = new LoggerFactory().CreateLogger<WeatherForecastController>();
            _controller = new WeatherForecastController(logger);

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IEnumerable<WeatherForecast>>(result);
        }
    }
}
