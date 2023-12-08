using be_semigura.Models;
using Data;
using Template;

namespace be_semigura.Repositories;

public class MoromiRepository : TRepository<Moromi, ApplicationDbContext>
{
    public MoromiRepository(ApplicationDbContext context) : base(context)
    {
    }
}


