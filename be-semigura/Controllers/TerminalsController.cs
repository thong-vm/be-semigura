using Models;
using Data;
using Template;

namespace Controllers;

public class TerminalsController : TController<Terminal, TRepository<Terminal, ApplicationDbContext>>
{
    public TerminalsController(TRepository<Terminal, ApplicationDbContext> repository) : base(repository)
    {
    }
}
