using Data;
using Models;
using Template;

namespace Controllers;

public class ProductsController : TController<Product, TRepository<Product, ApplicationDbContext>>
{
    public ProductsController(TRepository<Product, ApplicationDbContext> repository) : base(repository)
    {
    }
}
