using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class EntityFrameworkRepository : IPizzasRepository
{
    private readonly PizzaStoreContext dbContext;

    public EntityFrameworkRepository(PizzaStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Create(Pizza pizza)
    {
        dbContext.Pizzas.Add(pizza);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Pizzas.Where(game => game.Id == id)
                                     .ExecuteDelete();
    }

    public Pizza? Get(int id)
    {
        return dbContext.Pizzas.Find(id);
    }

    public IEnumerable<Pizza> GetAll()
    {
        return dbContext.Pizzas.AsNoTracking().ToList();
    }

    public void Update(Pizza updatedGame)
    {
        dbContext.Update(updatedGame);
        dbContext.SaveChanges();
    }
}
