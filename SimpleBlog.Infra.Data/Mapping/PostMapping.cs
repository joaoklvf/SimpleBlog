using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Infra.Data.Mapping;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Title)
            .HasColumnType("varchar(50)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Content)
            .HasColumnType("varchar(150)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnType("datetime");

        builder.OwnsOne(p => p.Author).HasKey(p => p.Id);
    }
}
