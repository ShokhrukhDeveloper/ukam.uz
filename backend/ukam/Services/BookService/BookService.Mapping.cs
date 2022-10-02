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
        Price = entity.Price,
        Type = ToModelEType(entity.Type),
        CheckBook = ToModelECheckBook(entity.CheckBook),
    };

    private EType ToModelEType(Backend.Uckam.Entities.EType entity)
    => entity switch
    {
        Entities.EType.DiplomIshi => Models.EType.DiplomIshi,
        Entities.EType.KursIshi => Models.EType.KursIshi,
        Entities.EType.Referat => Models.EType.Referat,
        _=> Models.EType.Kitoblar,
    };
    private ECheckBook ToModelECheckBook(Backend.Uckam.Entities.Enums.ECheckBook entity)
    => entity switch
    {
        Entities.Enums.ECheckBook.Tekshirildi => Models.ECheckBook.Tekshirildi,
        _=> Models.ECheckBook.Tekshirilmadi,
    };

}   
    