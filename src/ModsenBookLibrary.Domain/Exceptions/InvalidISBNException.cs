namespace ModsenBookLibrary.Domain.Exceptions;
public class InvalidISBNException : Exception
{
    public InvalidISBNException() : base("Provide valid ISBN")
    {
    }

    public InvalidISBNException(string isbnValue) : base($"Provide valid ISBN. Current value: {isbnValue}")
    {
        IsbnValue = isbnValue;
    }

    public string IsbnValue { get; init; }
}
