using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Endpoints
{
    public static class PizzaEndpoints
    {
        public static void MapPizzaEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/pizzas");

            group.MapGet("/", async (PizzaDb db) => await db.Pizzas.ToListAsync());
            group.MapPost("/", async (PizzaDb db, Pizza pizza) =>
            {
                await db.Pizzas.AddAsync(pizza);
                await db.SaveChangesAsync();
                return Results.Created($"/{pizza.Id}", pizza);
            });
            group.MapGet("/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
            group.MapPut("/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
            {
                var pizza = await db.Pizzas.FindAsync(id);
                if (pizza is null) return Results.NotFound();
                pizza.Name = updatepizza.Name;
                pizza.Description = updatepizza.Description;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
            group.MapDelete("/{id}", async (PizzaDb db, int id) =>
            {
                var pizza = await db.Pizzas.FindAsync(id);
                if (pizza is null) return Results.NotFound();
                db.Pizzas.Remove(pizza);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}
