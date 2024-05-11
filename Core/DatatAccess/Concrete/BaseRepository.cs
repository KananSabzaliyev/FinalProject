using Core.DatatAccess.Abstract;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DatatAccess.Concrete
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext,new()
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

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            } 
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

    }
}
