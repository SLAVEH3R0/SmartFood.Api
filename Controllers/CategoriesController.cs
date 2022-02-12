using Microsoft.AspNetCore.Mvc;
using SmartFood.Api.Models;
using SmartFood.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace SmartFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly DatabaseContext _db;

    public CategoriesController(DatabaseContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> Get() => await _db.Categories.ToListAsync();
}