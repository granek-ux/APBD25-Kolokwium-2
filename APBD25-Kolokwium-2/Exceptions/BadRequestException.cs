namespace APBD25_Kolokwium_2.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException()
    {
    }

    public BadRequestException(string? message) : base(message)
    {
    }

    public BadRequestException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}