using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataModel.GenericRepository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal CustomerDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository() {}
        public GenericRepository(CustomerDbContext customerDbContext)
        {
            context = customerDbContext;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToListAsync().Result;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> whereFilter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "",
            int? pageNumber = null, int? pageSize = null
            )
        {
            IQueryable<TEntity> query = dbSet;

            if (whereFilter != null)
            {
                query = query.Where(whereFilter);

            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (pageSize != null && pageNumber != null)
            {
                query = query.Skip(pageSize.Value * (pageNumber.Value - 1)).Take(pageSize.Value);
            }
            
            return query.ToList();
        }
    }

}
