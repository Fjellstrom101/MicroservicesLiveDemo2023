using System.ComponentModel.DataAnnotations;
using Domain.Common.Interfaces.DataAccess;

namespace Authorization.DataAccess.Models;

public class User : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public DateTime DateCreated { get; set; }

    public string Role { get; set; } = "Customer";
}