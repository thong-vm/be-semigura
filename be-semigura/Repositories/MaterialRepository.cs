using Models;
using Data;
using Template;

namespace Repositories;

public class MaterialRepository : TRepository<Material, ApplicationDbContext>
{
    public MaterialRepository(ApplicationDbContext context) : base(context)
    {
    }
}


