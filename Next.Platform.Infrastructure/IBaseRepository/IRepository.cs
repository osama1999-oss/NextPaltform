using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Next.Platform.Infrastructure.IBaseRepository
{
   public interface IRepository<T>
   {
       IList<T> Get();
       IList<T> FindBy(Expression<Func<T, bool>> predicate);
       void Add(T model);
       void Delete(T model);
       T Edit(T model);
       void Save();

   }
}
