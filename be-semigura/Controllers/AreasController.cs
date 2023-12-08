using Data;
using Models;
using Template;

namespace Controllers;

public class AreasController : TController<Area, TRepository<Area, ApplicationDbContext>>
{
    public AreasController(TRepository<Area, ApplicationDbContext> repository) : base(repository)
    {
    }
}