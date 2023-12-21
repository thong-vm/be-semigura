using Models;
using Data;
using Template;

namespace Repositories;

public class DataEntryRepository : TRepository<DataEntry, ApplicationDbContext>
{
    public DataEntryRepository(ApplicationDbContext context) : base(context)
    {
    }
}


