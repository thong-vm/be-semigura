using Data;
using Models;
using Template;

namespace Repositories;

public class DeliveryRepository : TRepository<Delivery, ApplicationDbContext>
{
    public DeliveryRepository(ApplicationDbContext context) : base(context)
    {
    }
}


