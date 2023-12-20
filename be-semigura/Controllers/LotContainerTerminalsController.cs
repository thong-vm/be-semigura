using Models;
using Data;
using Template;

namespace Controllers;

public class LotContainerTerminalsController : TController<LotContainerTerminal, TRepository<LotContainerTerminal, ApplicationDbContext>>
{
    public LotContainerTerminalsController(TRepository<LotContainerTerminal, ApplicationDbContext> repository) : base(repository)
    {
    }
}
