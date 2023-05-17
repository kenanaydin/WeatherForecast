using Application.Extensions;
using Application.Helpers;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Features.ForecastFeatures.Queries
{
    public class GetForecastForWeekQuery : IRequest<IEnumerable<WeatherForecastResponse>>
    {
        public int WeekSelection { get; set; }
        public class GetForecastForWeekQueryHandler : IRequestHandler<GetForecastForWeekQuery, IEnumerable<WeatherForecastResponse>>
        {
            private readonly IApplicationDbContext _context;
            public GetForecastForWeekQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<WeatherForecastResponse>> Handle(GetForecastForWeekQuery query, CancellationToken cancellationToken)
            {
                DateTime beginDate = DateTime.MinValue;
                DateTime endDate = DateTime.MaxValue;
                if(query.WeekSelection == (int)WeekSelections.CurrentWeek)
                {
                    beginDate = DateTime.Today.FirstDayOfWeek();
                    endDate = beginDate.AddDays(6);
                }
                else if(query.WeekSelection == (int)WeekSelections.NextWeek)
                {
                    beginDate = DateTime.Today.AddDays(7).FirstDayOfWeek();
                    endDate = beginDate.AddDays(6);
                }

                var weatherForecastResponseQuery = from forecast in _context.WeatherForecasts.Where(a => a.ForDate >= beginDate && a.ForDate <= endDate).OrderBy(x => x.ForDate)
                                       select new WeatherForecastResponse
                                       {
                                           ForDate = forecast.ForDate,
                                           ForDateString = forecast.ForDate.ToString("dd/MM/yyyy, dddd"),
                                           Temperature = forecast.Temperature,
                                           Description =  TemperatureHelper.GetTemperatureDescription(forecast.Temperature)
                                       };

                var weatherForecasts = weatherForecastResponseQuery.ToList();

                return weatherForecasts;
            }
        }
    }
}
