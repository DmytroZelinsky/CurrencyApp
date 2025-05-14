namespace CurrencyApp.Infrastructure.EF.Models;

public class Role
{
	public byte RolePK {  get; set; }

	public required string RoleName { get; set; }

	public ICollection<User> Users { get; set; } = [];
}
