#pragma warning disable
using Backend.Uckam.Entities.Enums;

namespace Backend.Uckam.Entities;

public class Book:EntityBase
{
    public string BookName { get; set; }
    public string Author { get; set; }
    public string Establish { get; set; }
    public string Content { get; set; }
    public string ConverImage { get; set; }
    public double Price { get; set; }
    public EType Type { get; set; }
    public ELanguage Language { get; set; }
    public ECheckBook CheckBook { get; set; }
    public ulong CategoryId { get; set; } 
    public ulong UserId { get; set; }
}