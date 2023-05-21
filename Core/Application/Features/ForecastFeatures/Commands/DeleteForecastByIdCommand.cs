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
            private readonly IWeatherForecastRepository _weatherForecastRepository;
            public DeleteForecastByIdCommandHandler(IWeatherForecastRepository weatherForecastRepository)
            {
                _weatherForecastRepository = weatherForecastRepository;
            }
            public async Task<int> Handle(DeleteForecastByIdCommand command, CancellationToken cancellationToken)
            {
                var weatherForecast = await _weatherForecastRepository.GetWeatherForecastByIdAsync(command.Id);
                if (weatherForecast == null) return default;
                await _weatherForecastRepository.DeleteAsync(weatherForecast);
                return weatherForecast.Id;
            }
        }
    }
}
