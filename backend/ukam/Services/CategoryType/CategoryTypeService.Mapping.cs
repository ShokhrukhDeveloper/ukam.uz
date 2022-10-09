#pragma warning disable
using Backend.Uckam.Models;
using ukam.Models;

namespace Backend.Uckam.Services;

public partial class CategoryTypeService
{
    private CategoryType ToModel(Backend.Uckam.Entities.CategoryType entity, Backend.Uckam.Entities.User? existingCreator, Backend.Uckam.Entities.Category? existingCategory)
    => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        User = ToModelUser(existingCreator!),
        Category = ToModel(existingCategory),
    };

    private Category ToModel(Entities.Category? entity)
    => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Image = entity.Image,
        CreatorId = entity.CreatorId,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
    };

    private static User ToModelUser(Backend.Uckam.Entities.User existingCreator)
    => new()
    {
        Id = existingCreator.Id,
        FirstName = existingCreator.FirstName,
        LastName = existingCreator.LastName,
        UserName = existingCreator.UserName,
        UserImage = existingCreator.UserPath,
        Role = ToModelERole(existingCreator.Role),
        Language = ToModelELanguage(existingCreator.Language),
        CreatedAt = existingCreator.CreatedAt,
        UpdatedAt = existingCreator.UpdatedAt,
    };

    private static Backend.Uckam.Models.ELanguage? ToModelELanguage(Backend.Uckam.Entities.Enums.ELanguage entity)
    => entity switch
    {
        Backend.Uckam.Entities.Enums.ELanguage.Eng => Backend.Uckam.Models.ELanguage.Eng,
        Backend.Uckam.Entities.Enums.ELanguage.Rus => Backend.Uckam.Models.ELanguage.Rus,
        _ => Backend.Uckam.Models.ELanguage.Uzb,
    };

    private static Backend.Uckam.Models.ERole? ToModelERole(Backend.Uckam.Entities.Enums.ERole entity)
    => entity switch
    {
        Backend.Uckam.Entities.Enums.ERole.Admin => Backend.Uckam.Models.ERole.Admin,
        Backend.Uckam.Entities.Enums.ERole.SuperAdmin => Backend.Uckam.Models.ERole.SuperAdmin,
        _ => Backend.Uckam.Models.ERole.User,

    };

    private CategoryType ToModelResult(Entities.CategoryType entity)
       => new()
       {
           Id = entity.Id,
           Name = entity.Name,
           CreatedAt = entity.CreatedAt,
           UpdatedAt = entity.UpdatedAt,
       };
}