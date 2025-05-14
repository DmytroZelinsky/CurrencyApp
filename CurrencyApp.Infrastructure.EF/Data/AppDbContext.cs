using System.Security.Cryptography;
using System.Text;

using CurrencyApp.Infrastructure.EF.Models;

using Microsoft.EntityFrameworkCore;

namespace CurrencyApp.Infrastructure.EF.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
	public DbSet<Role> Roles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<User>()
			.HasKey(u => u.UserPK);

		modelBuilder.Entity<Role>()
			.HasKey(r => r.RolePK);

		modelBuilder.Entity<User>()
			.HasOne(u => u.Role)
			.WithMany(r => r.Users)
			.HasForeignKey(u => u.RolePK)
			.IsRequired();

		modelBuilder.Entity<Role>().HasData(
			new Role { RolePK = 1, RoleName = "Admin" },
			new Role { RolePK = 2, RoleName = "User" }
		);

		modelBuilder.Entity<User>().HasData(
			new User
			{
				UserPK = Guid.Parse("b9ce9477-7eb6-4444-b411-554895bf3272"),
				UserName = "admin1",
				PasswordHash = BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes("admin1"))),
				RolePK = 1,
			},
			new User
			{
				UserPK = Guid.Parse("fe16b2fd-ab54-4a10-b69e-a43215ed7a75"),
				UserName = "user1",
				PasswordHash = BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes("user1"))),
				RolePK = 2
			}
		);
	}
}
