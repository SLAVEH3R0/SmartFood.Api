using Microsoft.AspNetCore.Mvc;
using SmartFood.Api.Models;

namespace SmartFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Recipe>> Get()
    {
        return await Task.FromResult(
            new List<Recipe>
            {
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = "Recipe 1",
                    PreparationTime = 10,
                    Servings = 2,
                    Ingredients = "Ingredient 1, Ingredient 2",
                    Description = "Description 1",
                    Category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Category 1"
                    },
                    Photo = "https://picsum.photos/id/1060/400/300",
                    CreatedAt = DateTime.Now
                },
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = "Recipe 2",
                    PreparationTime = 20,
                    Servings = 3,
                    Ingredients = "Ingredient 3, Ingredient 4",
                    Description = "Description 2",
                    Category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "Category 2"
                    },
                    Photo = "https://picsum.photos/id/1080/400/300",
                    CreatedAt = DateTime.Now
                }
            }
        );
    }
}