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
        TypeId = entity.TypeId,
        Check = entity.Check,
    };

    private EType ToModelEType(Backend.Uckam.Entities.EType entity)
    => entity switch
    {
        Entities.EType.DiplomIshi => Models.EType.DiplomIshi,
        Entities.EType.KursIshi => Models.EType.KursIshi,
        Entities.EType.Referat => Models.EType.Referat,
        _=> Models.EType.Kitoblar,
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

}   
    