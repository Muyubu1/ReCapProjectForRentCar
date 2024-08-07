using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//bu referansı yakalmak için yapılır ve bu referansı yakaladığımızda ekleme güncelleme silme işlemlerini yapabiliriz
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//ekleme işlemi yapılır
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//bu referansı yakalmak için yapılır ve bu referansı yakaladığımızda ekleme güncelleme silme işlemlerini yapabiliriz
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();//ekleme işlemi yapılır
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//bu referansı yakalmak için yapılır ve bu referansı yakaladığımızda ekleme güncelleme silme işlemlerini yapabiliriz
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();//ekleme işlemi yapılır
            }
        }
    }
}
