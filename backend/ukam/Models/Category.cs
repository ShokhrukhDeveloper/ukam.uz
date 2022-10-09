#pragma warning disable
namespace ukam.Models;
public class Category
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public ulong CreatorId { get; set; }
    public DateTime? CreatedAt { get; set; }=DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
