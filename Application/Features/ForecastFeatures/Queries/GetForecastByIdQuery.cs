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
            private readonly IApplicationDbContext _context;
            public GetForecastByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<WeatherForecast> Handle(GetForecastByIdQuery query, CancellationToken cancellationToken)
            {
                var weatherForecast = _context.WeatherForecasts.Where(a => a.Id == query.Id).FirstOrDefault();
                return weatherForecast;
            }
        }
    }
}
