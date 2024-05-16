using Core.DatatAccess.Abstract;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DatatAccess.Concrete
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var adddedEntity = context.Entry(entity);
                adddedEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }

        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedContext = context.Entry(entity);
                deletedContext.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }



        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                else
                {
                    return context.Set<TEntity>().Where(filter).ToList();
                }
            }
        }
    }
}
