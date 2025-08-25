using IWantApp.Endpoints.Categories;
using IWantApp.Infra.Data;
using IWantApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;







var builder = WebApplication.CreateSlimBuilder(args);
//builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:IWantDb"]);

//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseSqlServer(
//        builder.Configuration["ConnectionString:IWantDb"],
//        sqlServerOptions => sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
//    ).UseModel(ApplicationDbContextModel.Instance)); // Use a sobrecarga correta e UseModel

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionString:IWantDb"])
                      .UseModel(ApplicationDbContextModel.Instance)
);




builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});


    

var app = builder.Build();

//if(app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
[JsonSerializable(typeof(IWantApp.Endpoints.Categories.CategoryRequest))]
[JsonSerializable(typeof(IWantApp.Endpoints.Categories.CategoryPost))]
[JsonSerializable(typeof(OpenApiDocument))]
[JsonSerializable(typeof(OpenApiInfo))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
