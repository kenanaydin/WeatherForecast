using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AlreadyExistingForecastException : Exception
    {
        public AlreadyExistingForecastException(string forecastDateString) : base($"There is already an exisiting forecast for the date {forecastDateString}.")
        {
            ForecastDateString = forecastDateString;
        }

        public AlreadyExistingForecastException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public string ForecastDateString { get; }
    }
}
