using Microsoft.EntityFrameworkCore;
using TaskInforce.DAL.Models;

namespace TaskInforce.DAL
{
 
    public class ApplicationContext : DbContext
    {

          public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }

            public DbSet<Url> URLs { get; set; }

            public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "1111",
                    Email = "admin123@gmail.com",
                    Role = Enums.Role.Admin,
                });
 
        }
    }
}
