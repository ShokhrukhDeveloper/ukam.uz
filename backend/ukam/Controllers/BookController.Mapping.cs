#pragma warning disable
using Backend.Uckam.Dtos;

namespace Backend.Uckam.Controllers;

public partial class BookController
{
    private Models.Book ToModel(BookCreate dtos)
    => new()
    {
        BookName = dtos.BookName,
        Author = dtos.Author,
        Establish = dtos.Establish,
        Content = dtos.Content,
        Price = dtos.Price,
        Type = ToModelEType(dtos.Type),
        Language = ToELanguageModel(dtos.Language),
        CheckBook = ToModelECheckBook(dtos.CheckBook),
        CategoryId = dtos.CategoryId,
        UserId = dtos.UserId       
    };

    private Models.ELanguage ToELanguageModel(Dtos.ELanguage language)
    => language switch
    {
        Dtos.ELanguage.Eng => Models.ELanguage.Eng,
        Dtos.ELanguage.Rus => Models.ELanguage.Rus,
        _ => Models.ELanguage.Uzb
    };

    private Models.EType ToModelEType(Dtos.EType type)
    => type switch
    {
        Dtos.EType.DiplomIshi => Models.EType.DiplomIshi,
        Dtos.EType.KursIshi => Models.EType.KursIshi,
        Dtos.EType.Referat => Models.EType.Referat,
        _=> Models.EType.Kitoblar,
    };

    private Models.ECheckBook ToModelECheckBook(Dtos.ECheckBook dto)
    => dto switch
    {
        Dtos.ECheckBook.Tekshirildi => Models.ECheckBook.Tekshirildi,
        _=> Models.ECheckBook.Tekshirilmadi,
    } ;   
}