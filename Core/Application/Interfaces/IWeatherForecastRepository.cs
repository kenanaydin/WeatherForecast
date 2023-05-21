using Domain.Entities;

namespace Application.Interfaces
{
    public interface IWeatherForecastRepository : IGenericRepository<WeatherForecast>
    {
        Task<WeatherForecast> GetWeatherForecastByIdAsync(int id);
        Task<WeatherForecast> GetWeatherForecastByDateAsync(DateTime forDate);
        List<WeatherForecast> GetWeatherForecastsByDateRange(DateTime beginDate, DateTime endDate);
    }
}
