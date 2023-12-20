using Models;
using Data;
using Template;

namespace Controllers;

public class LotContainersController : TController<LotContainer, TRepository<LotContainer, ApplicationDbContext>>
{
    public LotContainersController(TRepository<LotContainer, ApplicationDbContext> repository) : base(repository)
    {
    }
}
