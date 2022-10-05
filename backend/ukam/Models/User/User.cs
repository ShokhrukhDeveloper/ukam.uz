#pragma warning disable
using Backend.Uckam.Models;

namespace Backend.Uckam.Models;

public class User
{
    public ulong Id { get; set; }
    public string? FirstName { get; set; }
    public string? UserName { get; set; }
    public string? LastName { get; set; }
    public string? UserImage { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; } = 0;
    public bool Block { get; set; }
    public ELanguage? Language { get; set; }
    public ERole? Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}