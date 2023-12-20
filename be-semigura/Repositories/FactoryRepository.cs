using Models;
using Data;
using Template;

namespace Repositories;

public class FactoryRepository : TRepository<Factory, ApplicationDbContext>
{
    public FactoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}


