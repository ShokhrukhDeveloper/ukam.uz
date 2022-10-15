using Type = ukam.Models.Type;

namespace ukam.Dtos.TypeDTO
{
    public class TypeResponseDTO
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public Type? Type { get; set; }
    }
}
