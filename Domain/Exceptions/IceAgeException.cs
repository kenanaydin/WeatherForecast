namespace Domain.Exceptions
{
    public class IceAgeException : Exception
    {
        public IceAgeException(int temperature): base($"The temperature set (whic is {temperature}) can not be lower than minus 60 degree.")
        {
            Temperature = temperature;
        }

        public IceAgeException(string message)
            : base(message)
        {
        }

        public IceAgeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public int Temperature { get; }
    }
}
