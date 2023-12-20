using Models;
using Data;
using Template;

namespace Repositories;

public class LotContainerRepository : TRepository<LotContainer, ApplicationDbContext>
{
    public LotContainerRepository(ApplicationDbContext context) : base(context)
    {
    }
}


