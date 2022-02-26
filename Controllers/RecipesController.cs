using Microsoft.AspNetCore.Mvc;
using SmartFood.Api.Models;
using SmartFood.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace SmartFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly DatabaseContext _db;

    public RecipesController(DatabaseContext db)
    {
        _db = db;
    }

    [HttpGet]
     public async Task<IEnumerable<Recipe>> Get()
     {
         var recipes = await _db.Recipes.ToListAsync();
         var categories = await _db.Categories.ToListAsync();

         foreach (var recipe in recipes)
         {
             recipe.Category = categories.Find(x => x.Id == recipe.CategoryId);
         }

         return recipes;
     }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> Get(int id)
    {
        var recipe = await _db.Recipes.FindAsync(id);

        if (recipe == null)
        {
            return NotFound();
        }

        var categories = await _db.Categories.ToListAsync();
        recipe.Category = categories.Find(x => x.Id == recipe.CategoryId);

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> Post(Recipe recipe)
    {
        if (recipe == null)
        {
            return BadRequest();
        }

        recipe.CreatedAt = DateTime.Now;

        if (recipe.Category?.Id != null)
         {
             var category = await _db.Categories.FindAsync(recipe.Category.Id);
             if (category != null)
             {
                 recipe.Category = null;
                 recipe.CategoryId = category.Id;
             }
         }

        _db.Recipes.Add(recipe);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
    }
}