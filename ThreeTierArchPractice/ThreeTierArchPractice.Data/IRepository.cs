using System;
using System.Collections.Generic;

namespace ThreeTierArchPractice.Data
{
    public interface IRepository<TEntity,TContext>
    {
        public void Add(TEntity item);

        public void Remove(TEntity item);

        public void Update(TEntity item);

        public IList<TEntity> GetAll();

    }
}
