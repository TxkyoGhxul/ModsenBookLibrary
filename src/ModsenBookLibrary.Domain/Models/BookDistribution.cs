using ModsenBookLibrary.Domain.Enums;
using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class BookDistribution : Entity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }

    public DateTime TakenAt { get; set; }
    public DateTime ShouldReturnAt { get; set; }

    public BookDistributionStatus Status { get; private set; }

    public BookDistribution()
    {
    }

    public BookDistribution(Guid userId, Guid bookId, DateTime shouldReturnAt)
    {
        UserId = userId;
        BookId = bookId;
        TakenAt = DateTime.UtcNow;
        ShouldReturnAt = shouldReturnAt;
        Status = BookDistributionStatus.Taken;
    }

    public void ReturnBook()
    {
        if (Status != BookDistributionStatus.Returned)
        {
            Status = BookDistributionStatus.Returned;
        }
    }
}
