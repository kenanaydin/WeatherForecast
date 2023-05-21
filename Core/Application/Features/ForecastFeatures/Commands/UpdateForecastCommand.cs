using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ForecastFeatures.Commands
{
    public class UpdateForecastCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Temperature { get; set; }

        public class UpdateForecastCommandHandler : IRequestHandler<UpdateForecastCommand, int>
        {
            private readonly IWeatherForecastRepository _weatherForecastRepository;
            public UpdateForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository)
            {
                _weatherForecastRepository = weatherForecastRepository;
            }

            public async Task<int> Handle(UpdateForecastCommand command, CancellationToken cancellationToken)
            {
                var weatherForecast = await _weatherForecastRepository.GetWeatherForecastByIdAsync(command.Id);

                if (weatherForecast == null)
                {
                    return default;
                }
                else
                {
                    weatherForecast.Temperature = command.Temperature;
                    await _weatherForecastRepository.AddAsync(weatherForecast);
                    return weatherForecast.Id;
                }
            }
        }
    }
}
