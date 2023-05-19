using Application.Interfaces;
using Domain.Entities;
using Moq;
using Xunit;
using FluentAssertions;
using static Application.Features.ForecastFeatures.Commands.CreateForecastCommand;
using Application.Features.ForecastFeatures.Commands;
using Shouldly;

namespace Application.Tests
{
    public class CreateForecastCommandTests
    {
        private Mock<IWeatherForecastRepository> _weatherForecastRepository;



        [Fact]
        public async Task When_NoForecastAlreadyForDate_Then_ForecastIsAdded()
        {
            _weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _weatherForecastRepository.Setup(x => x.GetWeatherForecastByDateAsync(It.IsAny<DateTime>())).Returns(Task.FromResult<WeatherForecast>(null));
            var handler = new CreateForecastCommandHandler(_weatherForecastRepository.Object);
            var result = await handler.Handle(new CreateForecastCommand { ForDate = DateTime.Today, Temperature = 8 }, CancellationToken.None);
            result.ShouldBeOfType<int>();
        }
    }
}