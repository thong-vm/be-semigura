using Data;
using Models;
using Template;

namespace Repositories;

public class TruckRepository : TRepository<Truck, ApplicationDbContext>
{
    public TruckRepository(ApplicationDbContext context) : base(context)
    {
    }
}


