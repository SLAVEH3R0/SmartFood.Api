using System.ComponentModel.DataAnnotations;

namespace SmartFood.Api.Models;

public class Category
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
}