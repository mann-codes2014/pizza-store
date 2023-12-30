using PizzaStore.Dtos;

namespace PizzaStore.Models;



public static class EntityExtensions
{
    public static PizzaDto AsDto(this Pizza pizza)
    {
        return new PizzaDto(pizza.Id, pizza.Name, pizza.Description);

    }
}