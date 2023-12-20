using Models;
using Data;
using Template;

namespace Controllers;

public class ContainersController : TController<Container, TRepository<Container, ApplicationDbContext>>
{
    public ContainersController(TRepository<Container, ApplicationDbContext> repository) : base(repository)
    {
    }
}
