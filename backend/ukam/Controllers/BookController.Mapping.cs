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
        Language = ToELanguageModel(dtos.Language),
        TypeId = dtos.TypeId,
        UserId = dtos.UserId       
    };

    private Models.ELanguage ToELanguageModel(Dtos.ELanguage language)
    => language switch
    {
        Dtos.ELanguage.Eng => Models.ELanguage.Eng,
        Dtos.ELanguage.Rus => Models.ELanguage.Rus,
        _ => Models.ELanguage.Uzb
    };  
}