namespace ViewModels.QueriesResponseViewModel.Category;

public class CategorySearchViewModel
{
    public int Id { get; set; }

    public CategoryBusinessType Type { get; set; }

    public string Name { get; set; } = null!;

    public string Route { get; set; } = null!;

    public int ParentId { get; set; }

    public short NodeLevel { get; set; }

    public bool IsLastNode { get; set; }
}