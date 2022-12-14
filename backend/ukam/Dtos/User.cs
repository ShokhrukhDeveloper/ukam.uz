#pragma warning disable
using Backend.Uckam.Models;

namespace Backend.Uckam.Dtos;

public class User
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public IFormFile UserImage { get; set; }
    public double Balance { get; set; }
    public bool Block { get; set; } = false;
    public ELanguage Language { get; set; } = ELanguage.Uzb;
    public ERole Role { get; set; } = ERole.User;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}