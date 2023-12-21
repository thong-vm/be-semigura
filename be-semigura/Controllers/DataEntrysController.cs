using Models;
using Data;
using Template;

namespace Controllers;

public class DataEntrysController : TController<DataEntry, TRepository<DataEntry, ApplicationDbContext>>
{
    public DataEntrysController(TRepository<DataEntry, ApplicationDbContext> repository) : base(repository)
    {
    }
}
