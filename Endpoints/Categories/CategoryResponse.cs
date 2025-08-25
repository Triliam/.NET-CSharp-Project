
namespace IWantApp.Endpoints.Categories;

internal class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public CategoryResponse(Guid id, string name, bool active)
    {
        this.Id = id;
        this.Name = name;
        this.Active = active;
    }
}