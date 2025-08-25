using IWantApp.Infra.Data;
using System.ComponentModel.Design;

namespace IWantApp.Endpoints.Categories;

public class CategoryGetAll
{

    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    //public static Guid Id { get; set; }
    //public static string Name { get; set; }
    //public static bool Active { get; set; }
    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.Select(c => new CategoryResponse( c.Id, c.Name,  c.Active)).ToList();

        return Results.Ok(categories);
    }
}
