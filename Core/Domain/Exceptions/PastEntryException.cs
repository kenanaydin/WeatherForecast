namespace Domain.Exceptions
{
    public class PastEntryException : Exception
    {
        public PastEntryException(string forecastDateString) : base($"It is not possible to make forecast entry for the date {forecastDateString} since it is a past date.")
        {
            ForecastDateString = forecastDateString;
        }

        public PastEntryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public string ForecastDateString { get; }
    }
}
