using System.ComponentModel.DataAnnotations;

namespace Backend.Uckam.Models;

public enum ECheckBook
{
    [Display(Name = "Tekshirilmadi")]  Tekshirilmadi = 0,

    [Display(Name = "Tekshirildi")] Tekshirildi = 1
}