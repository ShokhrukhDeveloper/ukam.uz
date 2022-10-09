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
    public string BookPath { get; set; }
    public double Price { get; set; }
    public bool Check { get; set; }
    public ELanguage Language { get; set; }
    public ulong TypeId { get; set; } 
    public ulong UserId { get; set; }
    public CategoryType? Types { get; set; }
    public User? Users { get; set; }

    [Obsolete("this constroctor obly be used by Ef Core")]
    public Book() { }

    public Book(Backend.Uckam.Models.Book model, string converImage, string bookPath, ELanguage language)
    {
        BookName = model.BookName;
        Author = model.Author;
        Establish = model.Establish;
        Content = model.Content;
        ConverImage =converImage;
        BookPath = bookPath;
        Price = model.Price;
        Check = model.Check;
        Language = language;
        TypeId = model.TypeId;
        UserId = model.UserId;
    }
}