using Models;
using Data;
using Template;

namespace Controllers;

public class FactorysController : TController<Factory, TRepository<Factory, ApplicationDbContext>>
{
    public FactorysController(TRepository<Factory, ApplicationDbContext> repository) : base(repository)
    {
    }
}
