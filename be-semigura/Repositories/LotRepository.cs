using Models;
using Data;
using Template;

namespace Repositories;

public class LotRepository : TRepository<Lot, ApplicationDbContext>
{
    public LotRepository(ApplicationDbContext context) : base(context)
    {
    }
}


