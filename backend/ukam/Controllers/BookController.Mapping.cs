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

     private Models.Book ToModel(BookUpdate dtos)
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

    private Dtos.Book ToDto(Models.Book model)
    => new()
    {
      Id = model.Id,
      BookName = model.BookName,
      Author = model.Author,
      Establish = model.Establish,
      Content = model.Content,
      ConverImage = model.ConverImage,
      BookPath = model.BookPath,
      Price = model.Price,
      Type = ToDtoEType(model.Type),
      Language = ToDtoELanguage(model.Language),
      CheckBook = ToDtoECheckBook(model.CheckBook),
    };
    private Dtos.EType ToDtoEType(Models.EType type)
    => type switch
    {
        Models.EType.DiplomIshi => Dtos.EType.DiplomIshi,
        Models.EType.KursIshi => Dtos.EType.KursIshi,
        Models.EType.Referat => Dtos.EType.Referat,
        _=> Dtos.EType.Kitoblar,
    };

    private Dtos.ELanguage ToDtoELanguage(Models.ELanguage type)
    => type switch
    {
       Models.ELanguage.Eng => Dtos.ELanguage.Eng,
       Models.ELanguage.Rus => Dtos.ELanguage.Rus,
       _=> Dtos.ELanguage.Uzb,
    };

    private Dtos.ECheckBook ToDtoECheckBook(Models.ECheckBook type)
    => type switch
    {
       Models.ECheckBook.Tekshirildi => Dtos.ECheckBook.Tekshirildi,
       _=> Dtos.ECheckBook.Tekshirilmadi,
    };

    

}