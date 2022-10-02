using System.ComponentModel.DataAnnotations;

namespace Backend.Uckam.Models;

public enum EType
{
    [Display(Name = "Diplom Ishi")] DiplomIshi = 0,
    [Display(Name = "Referat")] Referat = 1,
    [Display(Name = "Kurs Ishi")] KursIshi = 2,
    [Display(Name = "Kitoblar")] Kitoblar = 3
}