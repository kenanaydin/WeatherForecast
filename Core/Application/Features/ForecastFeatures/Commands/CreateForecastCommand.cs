using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.ForecastFeatures.Commands
{
    public class CreateForecastCommand : IRequest<int>
    {
        public int Temperature { get; set; }
        public DateTime ForDate { get; set; }

        public class CreateForecastCommandHandler : IRequestHandler<CreateForecastCommand, int>
        {
            private readonly IWeatherForecastRepository _weatherForecastRepository;
            public CreateForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository)
            {
                _weatherForecastRepository = weatherForecastRepository;
            }

            public async Task<int> Handle(CreateForecastCommand command, CancellationToken cancellationToken)
            {
                if(command.Temperature > 60)
                    throw new WelcomeToHellException(command.Temperature);

                if(command.Temperature < -60)
                    throw new IceAgeException(command.Temperature);

                if (command.ForDate < DateTime.Today)
                    throw new PastEntryException(command.ForDate.ToString("dd/MM/yyyy"));

                var exisitingRecord = await _weatherForecastRepository.GetWeatherForecastByDateAsync(command.ForDate);
                if(exisitingRecord != null)
                    throw new AlreadyExistingForecastException(command.ForDate.Date.ToString("dd/MM/yyyy"));

                var weatherForecast = new WeatherForecast();
                weatherForecast.Temperature = command.Temperature;
                weatherForecast.ForDate = command.ForDate.Date;
                weatherForecast.CreateDate = DateTime.Now;
                await _weatherForecastRepository.AddAsync(weatherForecast);
                return weatherForecast.Id;
            }
        }
    }
}
