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
            private readonly IApplicationDbContext _context;
            public CreateForecastCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateForecastCommand command, CancellationToken cancellationToken)
            {
                if(command.Temperature > 60)
                    throw new WelcomeToHellException(command.Temperature);

                if(command.Temperature < -60)
                    throw new IceAgeException(command.Temperature);

                if (command.ForDate < DateTime.Today)
                    throw new PastEntryException(command.ForDate.ToString("dd/MM/yyyy"));

                var exisitingRecord = _context.WeatherForecasts.Where(x => x.ForDate == command.ForDate.Date).FirstOrDefault();
                if(exisitingRecord != null)
                    throw new AlreadyExistingForecastException(command.ForDate.Date.ToString("dd/MM/yyyy"));

                var weatherForecast = new WeatherForecast();
                weatherForecast.Temperature = command.Temperature;
                weatherForecast.ForDate = command.ForDate.Date;
                weatherForecast.CreateDate = DateTime.Now;
                _context.WeatherForecasts.Add(weatherForecast);
                await _context.SaveChangesAsync();
                return weatherForecast.Id;
            }
        }
    }
}
