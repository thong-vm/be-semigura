using Data;
using Models;
using Template;

namespace Repositories;

public class AreaRepository : TRepository<Area, ApplicationDbContext>
{
    public AreaRepository(ApplicationDbContext context) : base(context)
    {
    }
}


