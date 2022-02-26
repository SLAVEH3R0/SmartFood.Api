using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartFood.Api.Models;

public class Recipe
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int PreparationTime { get; set; }

    [Required]
    public int Servings { get; set; }

    [Required]
    [StringLength(300)]
    public string Ingredients { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public string Photo { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}