namespace ModsenBookLibrary.Domain.Models.Base;

public abstract class NamedEntity : Entity
{
    public string Name { get; set; }
}
