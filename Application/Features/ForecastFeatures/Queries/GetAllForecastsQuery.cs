using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ForecastFeatures.Queries
{
    public class GetAllForecastsQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public class GetAllForecastsQueryHandler : IRequestHandler<GetAllForecastsQuery, IEnumerable<WeatherForecast>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllForecastsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<WeatherForecast>> Handle(GetAllForecastsQuery query, CancellationToken cancellationToken)
            {
                var weatherForecastList = await _context.WeatherForecasts.ToListAsync();
                if (weatherForecastList == null)
                {
                    return null;
                }
                return weatherForecastList.AsReadOnly();
            }
        }
    }
}
