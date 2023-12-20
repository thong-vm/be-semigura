using Models;
using Data;
using Template;

namespace Repositories;

public class TerminalRepository : TRepository<Terminal, ApplicationDbContext>
{
    public TerminalRepository(ApplicationDbContext context) : base(context)
    {
    }
}


