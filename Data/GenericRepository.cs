using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);

            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();

            return entity;
        }

        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public ICollection<T> Search(Expression<Func<T, bool>> expression)
        {
            var query = _context.Set<T>().AsQueryable();

            return query.Where(expression).ToList();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> match, string includePropreties = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(includePropreties))
            {

                foreach (var prop in includePropreties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop); 
                }
            }

            return query.FirstOrDefault(match);
        }

        public T Update(T entity)
        {
            T entityToUpdate = _context.Set<T>().Find(entity.Id);

            if(entityToUpdate is not null)
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();

            return entity;
        }
    }
}
