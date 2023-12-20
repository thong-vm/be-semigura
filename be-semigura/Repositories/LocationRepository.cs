using Models;
using Data;
using Template;

namespace Repositories;

public class LocationRepository : TRepository<be_semigura.Models.Location, ApplicationDbContext>
{
    public LocationRepository(ApplicationDbContext context) : base(context)
    {
    }
}


