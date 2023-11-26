using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Endpoints
{
    public static class PizzaEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
            endpoints.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
            {
                await db.Pizzas.AddAsync(pizza);
                await db.SaveChangesAsync();
                return Results.Created($"/pizza/{pizza.Id}", pizza);
            });
            endpoints.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
            endpoints.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
            {
                var pizza = await db.Pizzas.FindAsync(id);
                if (pizza is null) return Results.NotFound();
                pizza.Name = updatepizza.Name;
                pizza.Description = updatepizza.Description;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
            endpoints.MapDelete("pizza/{id}", async (PizzaDb db, int id) =>
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
