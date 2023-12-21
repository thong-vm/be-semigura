using Data;
using Interfaces;
using Models;
using System.Security.Claims;

namespace GraphQL
{
    public class Query
    {
        public User GetMe(ClaimsPrincipal claimsPrincipal)
        {
            return new User
            {
                Account = claimsPrincipal.FindFirstValue(ClaimTypes.Name),
                Role = claimsPrincipal.FindFirstValue(ClaimTypes.Role)
            };
        }
    }

    public class TQueryResolver<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IQueryable<TEntity> GetAll([Service] ApplicationDbContext db)
        {
            return db.Set<TEntity>();
        }
        public IQueryable<TEntity> GetOne([Service] ApplicationDbContext db, string id)
        {
            return db.Set<TEntity>().Where(e => e.Id == id);
        }
    }
    public class TQueryTypeExtension<TEntity> : ObjectTypeExtension
        where TEntity : class, IEntity, new()
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Authorize();
            descriptor.Name(nameof(Query));

            var getAllQuery = "getAll" + typeof(TEntity).Name + "s";
            descriptor
                .Field(getAllQuery.LowerFirstChar())
                .ResolveWith<TQueryResolver<TEntity>>(f => f.GetAll(default!))
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            var getOneQuery = "get" + typeof(TEntity).Name + "ById";
            descriptor
                .Field(getOneQuery.LowerFirstChar())
                .Argument("id", _ => _.Type<NonNullType<StringType>>())
                .ResolveWith<TQueryResolver<TEntity>>(f => f.GetOne(default!, default!))
                .UseProjection();
        }
    }
}
