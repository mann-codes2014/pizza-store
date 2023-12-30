using System.ComponentModel.DataAnnotations;
namespace PizzaStore.Models;

public class Pizza
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
}

