using System;
using System.Linq;
using DotnetTestDrivenDev.Controllers;
using Xunit;

namespace MyWebApi.Tests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Arrange
            var controller = new WeatherForecastController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_ReturnsWeatherForecastsWithValidData()
        {
            // Arrange
            var controller = new WeatherForecastController();

            // Act
            var result = controller.Get();

            // Assert
            foreach (var item in result)
            {
                Assert.NotNull(item.Date);
                Assert.InRange(item.TemperatureC, -20, 55);
                Assert.Contains(item.Summary, WeatherForecastController.Summaries);
            }
        }
    }
}
