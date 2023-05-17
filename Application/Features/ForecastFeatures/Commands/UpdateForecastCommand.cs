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
            private readonly IApplicationDbContext _context;
            public UpdateForecastCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateForecastCommand command, CancellationToken cancellationToken)
            {
                var weatherForecast = _context.WeatherForecasts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (weatherForecast == null)
                {
                    return default;
                }
                else
                {
                    weatherForecast.Temperature = command.Temperature;
                    await _context.SaveChangesAsync();
                    return weatherForecast.Id;
                }
            }
        }
    }
}
