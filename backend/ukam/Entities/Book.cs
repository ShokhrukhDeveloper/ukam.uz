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
    public EType Type { get; set; }
    public ELanguage Language { get; set; }
    public ECheckBook CheckBook { get; set; }
    public ulong CategoryId { get; set; } 
    public ulong UserId { get; set; }

    [Obsolete("this constroctor obly be used by Ef Core")]
    public Book() { }

    public Book(Backend.Uckam.Models.Book model, string converImage, string bookPath, ELanguage language, EType type, ECheckBook checkBook)
    {
        BookName = model.BookName;
        Author = model.Author;
        Establish = model.Establish;
        Content = model.Content;
        ConverImage =converImage;
        BookPath = bookPath;
        Price = model.Price;
        Type = type;
        Language = language;
        CheckBook = checkBook;
        CategoryId = model.CategoryId;
        UserId = model.UserId;
    }
}