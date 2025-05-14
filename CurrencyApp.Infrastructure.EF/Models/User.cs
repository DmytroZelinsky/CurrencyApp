namespace CurrencyApp.Infrastructure.EF.Models;

public class User
{
	public Guid UserPK { get; set; }

	public required string UserName { get; set; }

	public required string PasswordHash { get; set; }

	public required byte RolePK { get; set; }

	public Role Role {  get; set; }
}
