using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Dtos;

public record PizzaDto(
    int Id,
    string Name,
    string Description
);
public record CreatePizzaDto
(

    [Required] string Name,
    [Required] string Description


);