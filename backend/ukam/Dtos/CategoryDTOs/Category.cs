namespace ukam.Dtos.CategoryDTOs
{
    public class Category
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
