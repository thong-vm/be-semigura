using Models;
using Data;
using Template;

namespace Controllers;

public class MaterialsController : TController<Material, TRepository<Material, ApplicationDbContext>>
{
    public MaterialsController(TRepository<Material, ApplicationDbContext> repository) : base(repository)
    {
    }
}
