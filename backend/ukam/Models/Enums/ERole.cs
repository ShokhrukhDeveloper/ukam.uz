using System.ComponentModel.DataAnnotations;

namespace Backend.Uckam.Models;

public enum ERole
{
    [Display(Name = "User")] User = 0,
    [Display(Name = "Super admin")] SuperAdmin = 1,
    [Display(Name = "Admin")] Admin = 2,
}