using Models;
using Data;
using Template;

namespace Repositories;

public class SensorDataRepository : TRepository<SensorData, ApplicationDbContext>
{
    public SensorDataRepository(ApplicationDbContext context) : base(context)
    {
    }
}


