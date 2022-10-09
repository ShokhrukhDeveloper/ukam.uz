namespace Backend.Uckam.Models;

public class Book
{
    public ulong Id { get; set; }
    public string? BookName { get; set; }
    public string? Author { get; set; }
    public string? Establish { get; set; }
    public string? Content { get; set; }
    public string? ConverImage { get; set; }
    public double Price { get; set; }
    public ELanguage? Language { get; set; }
    public bool Check { get; set; }
    public ulong TypeId { get; set; } 
    public ulong UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}