using Backend.Uckam.Entities.Enums;

namespace Backend.Uckam.Entities;
public class User : EntityBase
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserImage  { get; set; }
    public ELanguage Language { get; set; } = ELanguage.Uzb;
    public ERole Role { get; set; } = ERole.User;
}