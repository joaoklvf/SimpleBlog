using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Infra.Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .HasColumnName("Id");

        builder.Property(u => u.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.UserName)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.BirthDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnType("datetime");

        builder.HasMany(u => u.Posts)
            .WithOne(u => u.Author)
            .HasForeignKey(u => u.AuthorId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

