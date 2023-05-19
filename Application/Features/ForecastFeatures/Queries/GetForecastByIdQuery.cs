using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ForecastFeatures.Queries
{
    public class GetForecastByIdQuery : IRequest<WeatherForecast>
    {
        public int Id { get; set; }
        public class GetForecastByIdQueryHandler : IRequestHandler<GetForecastByIdQuery, WeatherForecast>
        {
            private readonly IWeatherForecastRepository _weatherForecastRepository;
            public GetForecastByIdQueryHandler(IWeatherForecastRepository weatherForecastRepository)
            {
                _weatherForecastRepository = weatherForecastRepository;
            }
            public async Task<WeatherForecast> Handle(GetForecastByIdQuery query, CancellationToken cancellationToken)
            {
                var weatherForecast = await _weatherForecastRepository.GetWeatherForecastByIdAsync(query.Id);
                return weatherForecast;
            }
        }
    }
}
