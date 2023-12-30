using Microsoft.EntityFrameworkCore;
using PizzaStore.Dtos;
using PizzaStore.Models;
using PizzaStore.Repositories;

namespace PizzaStore.Endpoints
{
    public static class PizzaEndpoints
    {
        const string GetPizzaNameEndpointName = "GetPizza";

        public static RouteGroupBuilder MapPizzaEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/pizzas").WithParameterValidation();

            group.MapGet("/", (IPizzasRepository repository) => repository.GetAll().Select(game => game.AsDto()));
            group.MapPost("/", (IPizzasRepository repository, CreatePizzaDto pizzaDto) =>
            {
                Pizza pizza = new()
                {
                    Name = pizzaDto.Name,
                    Description = pizzaDto.Description,

                };
                repository.Create(pizza);
                return Results.CreatedAtRoute(GetPizzaNameEndpointName, new { id = pizza.Id }, pizza);
            });
            group.MapGet("/{id}", (IPizzasRepository repository, int id) =>
            {
                Pizza? pizza = repository.Get(id);
                return pizza is not null ? Results.Ok(pizza.AsDto()) : Results.NotFound();
            }).WithName(GetPizzaNameEndpointName);
            group.MapPut("/{id}", (IPizzasRepository repository, Pizza updatepizza, int id) =>
            {
                var pizza = repository.Get(id);
                if (pizza is null) return Results.NotFound();
                pizza.Name = updatepizza.Name;
                pizza.Description = updatepizza.Description;
                repository.Update(pizza);
                return Results.NoContent();
            });
            group.MapDelete("/{id}", (IPizzasRepository repository, int id) =>
            {
                var pizza = repository.Get(id);
                if (pizza is null) return Results.NotFound();
                repository.Delete(id);
                return Results.Ok();
            });
            return group;
        }
    }
}
