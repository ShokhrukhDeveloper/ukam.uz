using System.ComponentModel.DataAnnotations;

namespace ukam.Dtos.TypeDTO
{
    public class TypeDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CreatorId { get; set; }
    }
}
