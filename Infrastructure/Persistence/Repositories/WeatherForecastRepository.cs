using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class WeatherForecastRepository : GenericRepository<WeatherForecast>, IWeatherForecastRepository
    {
        private readonly DbSet<WeatherForecast> _weatherForecasts;

        public WeatherForecastRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _weatherForecasts = dbContext.Set<WeatherForecast>();
        }

        public async Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
        {
            var weatherForecast = await _weatherForecasts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return weatherForecast;
        }

        public async Task<WeatherForecast> GetWeatherForecastByDateAsync(DateTime forDate)
        {
            var weatherForecast = await _weatherForecasts.Where(x => x.ForDate == forDate).FirstOrDefaultAsync();
            return weatherForecast;
        }

        public List<WeatherForecast> GetWeatherForecastsByDateRange(DateTime beginDate, DateTime endDate)
        {
            var weatherForecasts =  _weatherForecasts.Where(x => x.ForDate >= beginDate && x.ForDate <= endDate).OrderBy(x => x.ForDate).ToList();
            return weatherForecasts;
        }
    }
}
