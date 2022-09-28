#pragma warning disable

using Backend.Uckam.Entities.Enums;

namespace Backend.Uckam.Entities;
public class User : EntityBase
{
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string UserImage { get; set; }
    public double Balance { get; set; }
    public bool Block { get; set; } = false;
    public ELanguage Language { get; set; } = ELanguage.Uzb;
    public ERole Role { get; set; } = ERole.User;
}