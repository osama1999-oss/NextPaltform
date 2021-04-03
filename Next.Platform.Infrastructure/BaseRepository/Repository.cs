using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Infrastructure.BaseRepository
{
   public class Repository<T> : IRepository<T> where T : class
    {
        readonly NextPlatformDbContext _entities;

        #region Constructor

        public Repository(NextPlatformDbContext _entities)
        {
            this._entities = _entities;
        }

        #endregion

        public void Add(T model)
        {
            _entities.Set<T>().Add(model);
            Save();
        }

        public void Delete(T model)
        {
            _entities.Remove(model);
            Save();
        }

        public T Edit(T model)
        {
            _entities.Set<T>().Update(model);
            Save();
            return model;
        }

        public IList<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().Where(predicate).ToList();
        }

        public IList<T> Get()
        {
            return _entities.Set<T>().ToList();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
