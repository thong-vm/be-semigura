using Data;
using Models;
using Template;

namespace Repositories;

public class ProductRepository : TRepository<Product, ApplicationDbContext>
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}


