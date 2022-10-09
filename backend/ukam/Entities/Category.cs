#pragma warning disable
using System.ComponentModel.DataAnnotations;

namespace Backend.Uckam.Entities;

public class Category : EntityBase
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public ulong CreatorId { get; set; }
    // Navigation Properies
    public IEnumerable<Backend.Uckam.Entities.CategoryType>? CategoryTypes { get; set; }
 }