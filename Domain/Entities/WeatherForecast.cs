using Domain.Common;

namespace Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        public DateTime ForDate { get; set; }
        public int Temperature { get; set; }
    }
}
