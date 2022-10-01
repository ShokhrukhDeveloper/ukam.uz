using ukam.Dtos.CategoryDTOs;
using ukam;

namespace ukam.Controllers
{
    public partial class CategoryController
    {
        public Category ToDTO(Models.Category model) => new() 
        {
            Id = model.Id,
            Name = model.Name,
            Image=model.Image,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}
