#pragma warning disable

using Backend.Uckam.Models;

namespace ukam.Models;
public class CategoryType
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public ulong CategoryId { get; set;}
    public ulong UserId { get; set;}
    public User? User { get; set; }
    public Category? Category { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
