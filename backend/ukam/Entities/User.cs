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

    [Obsolete("this constroctor obly be used by Ef Core")]
    public User() { }

    public User(Backend.Uckam.Models.User model, string userImage, ELanguage language, ERole role)
    {
        FirstName = model.FirstName;
        LastName = model.LastName;
        UserName = model.UserName;
        UserImage = userImage;
        PasswordHash = model.PasswordHash;
        Block = model.Block;
        Balance = model.Balance;
        Language = language;
        Role = role;
    }
}