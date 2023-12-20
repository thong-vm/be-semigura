using Models;
using Data;
using Template;

namespace Controllers;

public class SensorDatasController : TController<SensorData, TRepository<SensorData, ApplicationDbContext>>
{
    public SensorDatasController(TRepository<SensorData, ApplicationDbContext> repository) : base(repository)
    {
    }
}
