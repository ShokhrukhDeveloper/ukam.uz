namespace ukam.Dtos.CategoryDTOs;
    public class UpdateCategory
    {
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public ulong UserId {get; set;}
    }
