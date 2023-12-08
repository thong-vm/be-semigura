using Data;
using HotChocolate;
using HotChocolate.Subscriptions;
using Interfaces;
using Repositories;
using Template;

namespace GraphQL
{
    public class Mutation
    {
        public async Task<Models.File?> UploadFileAsync([Service] TRepository<Models.File, ApplicationDbContext> repo, IFile file, string? id)
        {
            FileRepository fileRepo = (FileRepository)repo;

            var fileName = file.Name;
            _ = file.Length;


            //await using Stream stream = file.OpenReadStream();
            //var ms = new MemoryStream();
            //await file.CopyToAsync(ms);
            //var buffer = ms.ToArray();

            var savedPath = System.IO.Path.Combine(fileRepo.GetUploadPath(), fileName);
            if (System.IO.File.Exists(savedPath))
            {
                System.IO.File.Delete(savedPath);
            }

            //System.IO.File.WriteAllBytes(savedPath, buffer);
            //var base64 = Convert.ToBase64String(buffer);

            await using var stream = new FileStream(savedPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            await file.CopyToAsync(stream);

            var newFile = new Models.File();
            newFile.Id = id ?? newFile.Id;
            newFile.Path = savedPath;
            await fileRepo.Add(newFile);

            return newFile;
        }
    }

    public class TMutateResolver<TEntity>
    where TEntity : class, IEntity, new()
    {
        public async Task<TEntity?> Add([Service] TRepository<TEntity, ApplicationDbContext> repo, [Service] ITopicEventSender sender, TEntity input)
        {
            try
            {
                TEntity newObj = new();
                foreach (var property in typeof(TEntity).GetProperties())
                {
                    var inputValue = property.GetValue(input);
                    var defaultValue = property.GetValue(newObj);
                    property.SetValue(newObj, inputValue ?? defaultValue);
                }
                var added = await repo.Add(newObj);
                if (added != null)
                {
                    var topic = Subscription.GetAddedTopic<TEntity>();
                    await sender.SendAsync(topic, newObj);
                    return newObj;
                }

                throw new Exception($"Add {typeof(TEntity)} error!");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        public async Task<TEntity?> Update([Service] TRepository<TEntity, ApplicationDbContext> repo, [Service] ITopicEventSender sender, TEntity input, string id)
        {
            try
            {
                var found = await repo.Update(input, id);
                if (found != null)
                {
                    var topic = Subscription.GetUpdatedTopic<TEntity>();
                    await sender.SendAsync(topic, found);
                }
                return found;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        // if not found id then return null
        // else return deleted obj
        public async Task<TEntity?> Delete([Service] TRepository<TEntity, ApplicationDbContext> repo, [Service] ITopicEventSender sender, string id)
        {
            try
            {
                var found = await repo.Delete(id);
                if (found != null)
                {
                    var topic = Subscription.GetDeletedTopic<TEntity>();
                    await sender.SendAsync(topic, found);
                }
                return found;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

    }

    public class TMutateTypeExtension<TEntity> : ObjectTypeExtension
        where TEntity : class, IEntity, new()
    {
        enum MutateAction
        {
            Create, Update, Delete
        }
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Authorize();
            descriptor.Name(nameof(Mutation));

            var addAction = nameof(MutateAction.Create) + typeof(TEntity).Name;
            descriptor
                .Field(addAction.LowerFirstChar())
                .Argument("input", a => a.Type<NonNullType<InputObjectType<TEntity>>>())
                .ResolveWith<TMutateResolver<TEntity>>(f => f.Add(default!, default!, default!));

            var updateAction = nameof(MutateAction.Update) + typeof(TEntity).Name;
            descriptor
                .Field(updateAction.LowerFirstChar())
                .Argument("input", a => a.Type<NonNullType<InputObjectType<TEntity>>>())
                .Argument("id", _ => _.Type<NonNullType<StringType>>())
                .ResolveWith<TMutateResolver<TEntity>>(f => f.Update(default!, default!, default!, default!));

            var deleteAction = nameof(MutateAction.Delete) + typeof(TEntity).Name;
            descriptor
                .Field(deleteAction.LowerFirstChar())
                .Argument("id", _ => _.Type<NonNullType<StringType>>())
                .ResolveWith<TMutateResolver<TEntity>>(f => f.Delete(default!, default!, default!));
        }
    }
}
