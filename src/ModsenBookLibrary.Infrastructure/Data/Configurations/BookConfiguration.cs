using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Infrastructure.Data.Configurations;
internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(25);

        builder.Property(b => b.Description).IsRequired().HasMaxLength(250);

        builder.Property(b => b.ISBN).HasConversion(
            isbn => isbn.Value,
            value => ISBN.From(value)).IsRequired();
    }
}
