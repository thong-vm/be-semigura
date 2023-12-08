using be_semigura.Models;
using Data;
using Template;

namespace be_semigura.Controllers;

public class MoromisController : TController<Moromi, TRepository<Moromi, ApplicationDbContext>>
{
    public MoromisController(TRepository<Moromi, ApplicationDbContext> repository) : base(repository)
    {
    }
}
