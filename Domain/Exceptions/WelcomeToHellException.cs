namespace Domain.Exceptions
{
    public class WelcomeToHellException : Exception
    {
        public WelcomeToHellException(int temperature) : base($"The temperature set (which is {temperature}) can not be higher than 60 degree.")
        {
            Temperature = temperature;
        }

        public WelcomeToHellException(string message)
            : base(message)
        {
        }

        public WelcomeToHellException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public int Temperature { get; }
    }
}
