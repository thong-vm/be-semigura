using Data;
using Template;

namespace Controllers;

public class LocationsController : TController<be_semigura.Models.Location, TRepository<be_semigura.Models.Location, ApplicationDbContext>>
{
    public LocationsController(TRepository<be_semigura.Models.Location, ApplicationDbContext> repository) : base(repository)
    {
    }
}
