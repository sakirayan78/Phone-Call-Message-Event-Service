using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ByX.Model.Common;


namespace ByX.Repository.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.AsNoTracking().Where(predicate).AsEnumerable(); 
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            ///entity baglı olmadıgından bu işlem yapıldı
            /// normalde ProductfindbyId deseydik buna gerek kalmıcaktı
            /// 
            var entry = _entities.Entry(entity);
            if (entry.State == EntityState.Detached)
                _entities.Set<T>().Attach(entity);
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
