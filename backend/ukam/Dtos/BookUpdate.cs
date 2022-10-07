namespace Backend.Uckam.Dtos;

public class BookUpdate
{
    public string? BookName { get; set; }
    public string? Author { get; set; }
    public string? Establish { get; set; }
    public string? Content { get; set; }
    public IFormFile? ConverImage { get; set; }
    public IFormFile? BookFile { get; set; }
    public double Price { get; set; }
    public EType Type { get; set; }
    public ELanguage Language { get; set; }
    public ECheckBook CheckBook { get; set; }
    public ulong CategoryId { get; set; } 
    public ulong UserId { get; set; }
}