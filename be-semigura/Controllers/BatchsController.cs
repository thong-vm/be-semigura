using be_semigura.Models;
using Data;
using Template;

namespace be_semigura.Controllers
{
    public class BatchsController : TController<Batch, TRepository<Batch, ApplicationDbContext>>
    {
        public BatchsController(TRepository<Batch, ApplicationDbContext> repository) : base(repository)
        {
        }
    }

}
