using Models;
using Data;
using Template;

namespace Repositories;

public class ContainerRepository : TRepository<Container, ApplicationDbContext>
{
    public ContainerRepository(ApplicationDbContext context) : base(context)
    {
    }
}


