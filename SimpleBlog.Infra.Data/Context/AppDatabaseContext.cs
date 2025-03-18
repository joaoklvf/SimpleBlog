using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Infra.Data.Context;

public class AppDatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}