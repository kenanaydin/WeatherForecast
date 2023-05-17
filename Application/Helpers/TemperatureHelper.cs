namespace Application.Helpers
{
    public static class TemperatureHelper
    {
        public static string GetTemperatureDescription(int temperature)
        {
            switch (temperature)
            {
                case var expression when temperature >= -60 && temperature <=  0:
                    return "Freezing";
                case var expression when temperature >= 1 && temperature <= 10:
                    return "Bracing";
                case var expression when temperature >= 11 && temperature <= 15:
                    return "Chilly";
                case var expression when temperature >= 16 && temperature <= 19:
                    return "Cool";
                case var expression when temperature >= 20 && temperature <= 24:
                    return "Mild";
                case var expression when temperature >= 25 && temperature <= 29:
                    return "Warm";
                case var expression when temperature >= 30 && temperature <= 34:
                    return "Balmy";
                case var expression when temperature >= 35 && temperature <= 60:
                    return "Hot";
                default:
                    return "Undefined";
            }
        }
    }
}
