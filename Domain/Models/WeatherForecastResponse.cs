namespace Domain.Models
{
    public class WeatherForecastResponse
    {
        public DateTime ForDate { get; set; }
        public string ForDateString { get; set; }
        public int Temperature {  get; set; }
        public string Description { get; set; }
    }
}
