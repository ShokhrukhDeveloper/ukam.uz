using System.ComponentModel.DataAnnotations;

namespace Backend.Uckam.Dtos;

public enum ECheckBook
{
    [Display(Name = "Tekshirilmadi")]  Tekshirilmadi = 0,

    [Display(Name = "Tekshirildi")] Tekshirildi = 1
}