using Data;
using Models;
using Template;

namespace Controllers;

public class TrucksController : TController<Truck, TRepository<Truck, ApplicationDbContext>>
{
    public TrucksController(TRepository<Truck, ApplicationDbContext> repository) : base(repository)
    {
    }
}
