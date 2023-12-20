using Models;
using Data;
using Template;

namespace Controllers;

public class LotsController : TController<Lot, TRepository<Lot, ApplicationDbContext>>
{
    public LotsController(TRepository<Lot, ApplicationDbContext> repository) : base(repository)
    {
    }
}
