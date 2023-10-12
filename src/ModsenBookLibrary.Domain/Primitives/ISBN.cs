using ModsenBookLibrary.Domain.Exceptions;
using System.Text.RegularExpressions;
using ValueOf;

namespace ModsenBookLibrary.Domain.Primitives;
public class ISBN : ValueOf<string, ISBN>
{
    private const string _isbnPattern = "(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})";
    
    private static readonly Regex _isbnRegex = new(_isbnPattern);

    protected override void Validate()
    {
        var match = _isbnRegex.Match(Value);
        if (!match.Success)
        {
            throw new InvalidISBNException(Value);
        }
    }

    protected override bool TryValidate()
    {
        try
        {
            Validate();
            return true;
        }
        catch (InvalidISBNException)
        {
            return false;
        }
    }

    public static implicit operator string(ISBN isbn) => isbn.Value;

    //public static explicit operator ISBN(string isbnValue) => From(isbnValue);
}
