using Backend.Uckam.Models;

namespace Backend.Uckam.Services.BookService;

public partial class BookService
{
    public Book ToModel(Backend.Uckam.Entities.Book entity ) => new()
    {
        Id = entity.Id,
        BookName = entity.BookName,
        Author = entity.Author,
        Establish = entity.Establish,
        Content = entity.Content,
        ConverImage = entity.ConverImage,
        BookPath= entity.BookPath,
        Price = entity.Price,
        Type = ToModelEType(entity.Type),
        CheckBook = ToModelECheckBook(entity.CheckBook),
        Language = ToModelELanguage(entity.Language),
        CategoryId = entity.CategoryId,
        UserId = entity.UserId,
    };

    private ELanguage ToModelELanguage(Backend.Uckam.Entities.Enums.ELanguage? entity)
    => entity switch
    {
      Entities.Enums.ELanguage.Eng => Models.ELanguage.Eng,
      Entities.Enums.ELanguage.Rus => Models.ELanguage.Rus,
      _=> Models.ELanguage.Uzb,
    };

    private EType ToModelEType(Backend.Uckam.Entities.EType? entity)
    => entity switch
    {
        Entities.EType.DiplomIshi => Models.EType.DiplomIshi,
        Entities.EType.KursIshi => Models.EType.KursIshi,
        Entities.EType.Referat => Models.EType.Referat,
        _=> Models.EType.Kitoblar,
    };
    private ECheckBook ToModelECheckBook(Backend.Uckam.Entities.Enums.ECheckBook? entity)
    => entity switch
    {
        Entities.Enums.ECheckBook.Tekshirildi => Models.ECheckBook.Tekshirildi,
        _=> Models.ECheckBook.Tekshirilmadi,
    };

    private Entities.Enums.ELanguage ToEntityELanguage(ELanguage model)
    => model switch
    {
       Models.ELanguage.Eng => Entities.Enums.ELanguage.Eng,
       Models.ELanguage.Rus => Entities.Enums.ELanguage.Rus,
       _=> Entities.Enums.ELanguage.Uzb,
    };
    private Entities.EType ToEntityEtype(EType model)
    => model switch
    {
       Models.EType.DiplomIshi => Entities.EType.DiplomIshi,
       Models.EType.KursIshi => Entities.EType.KursIshi,
       Models.EType.Referat => Entities.EType.Referat,
      _=> Entities.EType.Kitoblar,
    };

    private Entities.Enums.ECheckBook ToEntityECheckBook(ECheckBook model)
    => model switch
    {
        Models.ECheckBook.Tekshirildi => Entities.Enums.ECheckBook.Tekshirildi,
        _=> Entities.Enums.ECheckBook.Tekshirilmadi,
    };

}   
    