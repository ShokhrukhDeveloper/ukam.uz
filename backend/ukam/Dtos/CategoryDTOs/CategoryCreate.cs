using System.ComponentModel.DataAnnotations;

namespace ukam.Dtos.CategoryDTOs;
    public class CategoryCreate
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public ulong UserId { get; set; }
}


