using Backend.Uckam.Models;

namespace Backend.Uckam.Services;

public partial class UserService
{
    private Entities.Enums.ELanguage ToEntityLanguage(ELanguage model)
   => model switch
   {
       ELanguage.Eng => Entities.Enums.ELanguage.Eng,
       ELanguage.Rus => Entities.Enums.ELanguage.Rus,
       _ => Entities.Enums.ELanguage.Uzb,
   };

    private Entities.Enums.ERole ToEntityRole(ERole model)
    => model switch
    {
        ERole.Admin => Entities.Enums.ERole.Admin,
        ERole.SuperAdmin => Entities.Enums.ERole.SuperAdmin,
        _ => Entities.Enums.ERole.User
    };

    private Models.ELanguage ToModelELanguage(Entities.Enums.ELanguage entity)
    => entity switch
    {
        Entities.Enums.ELanguage.Eng => Models.ELanguage.Eng,
        Entities.Enums.ELanguage.Rus => Models.ELanguage.Rus,
        _ => Models.ELanguage.Uzb,
    };

    private Models.ERole ToModelERole(Entities.Enums.ERole entity)
    => entity switch
    {
        Entities.Enums.ERole.Admin => Models.ERole.Admin,
        Entities.Enums.ERole.SuperAdmin => Models.ERole.SuperAdmin,
        _ => Models.ERole.User,
    };

      private User ToModel(Entities.User entity)
    => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        UserName = entity.UserName,
        UserImage = entity.UserPath,
        Role = ToModelERole(entity.Role),
        Language = ToModelELanguage(entity.Language),
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
    };
}