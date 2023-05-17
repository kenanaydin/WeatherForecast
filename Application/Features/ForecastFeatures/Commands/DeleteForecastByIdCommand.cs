using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ForecastFeatures.Commands
{
    public class DeleteForecastByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteForecastByIdCommandHandler : IRequestHandler<DeleteForecastByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteForecastByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteForecastByIdCommand command, CancellationToken cancellationToken)
            {
                var weatherForecast = await _context.WeatherForecasts.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (weatherForecast == null) return default;
                _context.WeatherForecasts.Remove(weatherForecast);
                await _context.SaveChangesAsync();
                return weatherForecast.Id;
            }
        }
    }
}
