using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTierArchPractice.Data
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext> 
        where TEntity : class where TContext : DbContext
    {
        protected TContext _context;
        protected DbSet<TEntity> _dbSet;
        public Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity item)
        {
            _dbSet.Add(item);
           // _context.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);
        }
    }
}
