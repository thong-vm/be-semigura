using be_semigura.Models;
using Data;
using Template;

namespace be_semigura.Repositories;

public class BatchRepository : TRepository<Batch, ApplicationDbContext>
{
    public BatchRepository(ApplicationDbContext context) : base(context)
    {
    }
}


