using Data;
using Models;
using Template;

namespace Controllers;

public class DeliverysController : TController<Delivery, TRepository<Delivery, ApplicationDbContext>>
{
    public DeliverysController(TRepository<Delivery, ApplicationDbContext> repository) : base(repository)
    {
    }
}
