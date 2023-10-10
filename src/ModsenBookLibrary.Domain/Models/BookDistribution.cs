using ModsenBookLibrary.Domain.Enums;
using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class BookDistribution : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public DateTime TakenAt { get; set; }
    public DateTime ShouldReturnAt { get; set; }

    public BookDistributionStatus Status { get; set; }
}
