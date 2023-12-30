using PizzaStore.Models;

namespace PizzaStore.Repositories;

public interface IPizzasRepository
{
    void Create(Pizza pizza);
    void Delete(int id);
    Pizza? Get(int id);
    IEnumerable<Pizza> GetAll();
    void Update(Pizza updatedGame);
}
