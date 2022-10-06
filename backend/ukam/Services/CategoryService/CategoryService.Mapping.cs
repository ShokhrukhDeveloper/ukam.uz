using ukam.Models;

namespace ukam.Services.CategoryService;
    public partial class CategoryService
    {
    
    public Category ToModel(Backend.Uckam.Entities.Category entity) => new()
        { 
            Id = entity.Id,
            Name = entity.Name,
            CreatedAt = entity.CreatedAt,
            Image = entity.Image,
            UpdatedAt = entity.UpdatedAt,   
            CreatorId = entity.CreatorId
        };
    public Backend.Uckam.Entities.Category ToEntity(Category model) => new() 
        { 
            Name = model.Name,
            Id = model.Id,
            CreatedAt = model.CreatedAt??DateTime.Now,
            CreatorId = model.CreatorId,
            Image = model.Image,
            UpdatedAt = model.UpdatedAt??DateTime.Now
        };
    }


