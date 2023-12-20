using Models;
using Data;
using Template;

namespace Repositories;

public class LotContainerTerminalRepository : TRepository<LotContainerTerminal, ApplicationDbContext>
{
    public LotContainerTerminalRepository(ApplicationDbContext context) : base(context)
    {
    }
}


