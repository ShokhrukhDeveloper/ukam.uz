namespace Backend.Uckam.Entities;

public class CategoryType : EntityBase
{
    public string? Name { get; set; }
    // Navigation Properties
    public ulong CreatorId { get; set; }
    public User? User { get; set; }
    public ulong CategoryId { get; set; }
    public Category? Category { get; set; }
    public IEnumerable<Book>? Books { get; set; }

    [Obsolete("this constroctor obly be used by Ef Core")]
    public CategoryType() { }

    public CategoryType(string name, ulong creatorId, ulong categoryId)
    {
        Name = name;
        CreatorId = creatorId;
        CategoryId = categoryId;
    }
}