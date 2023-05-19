using Application.Interfaces;
using Domain.Entities;
using Moq;
using Xunit;
using FluentAssertions;
using static Application.Features.ForecastFeatures.Commands.CreateForecastCommand;
using Application.Features.ForecastFeatures.Commands;
using Shouldly;
using Domain.Exceptions;

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

        [Fact]
        public async Task When_TemperatureIsGreaterThan60_Then_ThrowWelcomeToHellException()
        {
            _weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _weatherForecastRepository.Setup(x => x.GetWeatherForecastByDateAsync(It.IsAny<DateTime>())).Returns(Task.FromResult<WeatherForecast>(null));
            var handler = new CreateForecastCommandHandler(_weatherForecastRepository.Object);
            await Assert.ThrowsAsync<WelcomeToHellException>(() => handler.Handle(new CreateForecastCommand { ForDate = DateTime.Today, Temperature = 62 }, CancellationToken.None));
        }

        [Fact]
        public async Task When_TemperatureIsLessThanMinus60_Then_ThrowIceAgeException()
        {
            _weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _weatherForecastRepository.Setup(x => x.GetWeatherForecastByDateAsync(It.IsAny<DateTime>())).Returns(Task.FromResult<WeatherForecast>(null));
            var handler = new CreateForecastCommandHandler(_weatherForecastRepository.Object);
            await Assert.ThrowsAsync<IceAgeException>(() => handler.Handle(new CreateForecastCommand { ForDate = DateTime.Today, Temperature = -80 }, CancellationToken.None));
        }

        [Fact]
        public async Task When_ForDateIsAlreadyPassed_Then_PastEntryException()
        {
            _weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _weatherForecastRepository.Setup(x => x.GetWeatherForecastByDateAsync(It.IsAny<DateTime>())).Returns(Task.FromResult<WeatherForecast>(null));
            var handler = new CreateForecastCommandHandler(_weatherForecastRepository.Object);
            await Assert.ThrowsAsync<PastEntryException>(() => handler.Handle(new CreateForecastCommand { ForDate = DateTime.Today.AddDays(-2), Temperature = 32 }, CancellationToken.None));
        }
    }
}