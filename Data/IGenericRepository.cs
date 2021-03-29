using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        T Get(long id);
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        T FirstOrDefault(Expression<Func<T, bool>> match, string includePropreties = null);
        void Delete(long id);
    }
}
