namespace ModsenBookLibrary.Domain.Exceptions;
public class DublicateException : Exception
{
    public DublicateException() : base("Entity is already exists database")
    {
    }
}
