using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Infrastructure.Data.Configurations;

internal class BookDistributionConfiguration : IEntityTypeConfiguration<BookDistribution>
{
    public void Configure(EntityTypeBuilder<BookDistribution> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.UserId).IsRequired();

        builder.Property(b => b.BookId).IsRequired();

        builder.Property(b => b.Status).IsRequired();

        builder.Property(b => b.TakenAt).IsRequired();

        builder.Property(b => b.ShouldReturnAt).IsRequired();
    }
}