namespace Travel.BackEnd.Exceptions
{
    public class DestinationNotFoundException : Exception
    {
        public DestinationNotFoundException(string message) : base(message) { }
    }
}
