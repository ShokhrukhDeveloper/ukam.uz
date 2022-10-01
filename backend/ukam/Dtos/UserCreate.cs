#pragma warning disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Uckam.Dtos;

public class UserCreate
{
    public string? FirstName { get; set; }
    public string? UserName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }
    public IFormFile? UserImage { get; set; }
    public double? Balance { get; set; }
    public bool? Block { get; set; }
    public ELanguage? Language { get; set; }
    public ERole? Role { get; set; }
}