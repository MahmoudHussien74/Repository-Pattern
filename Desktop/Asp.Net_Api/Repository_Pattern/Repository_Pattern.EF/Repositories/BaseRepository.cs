using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Core.Const;
using Repository_Pattern.Core.Interfaces;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository_Pattern.EF.Repositories
{
    public class BaseRepository<T>(ApplicationDbcontext context) : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbcontext _context = context;

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match)!;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id) => _context.Set<T>().Find(id)!;

        public async Task<T> GetByIdAsync(int id)
        {
           return  await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null!)
        {
            IQueryable<T> query = _context.Set<T>();

            if(includes !=null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return query.SingleOrDefault(match);

        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>(); 
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip)
        {
            return _context.Set<T>().Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip, Expression<Func<T, object>> OrderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = _context.Set<T>().Where(match);

            if(take.HasValue)
            {
                query = query.Take(take.Value);
            }
            if(skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if(OrderBy != null)
            {

                if (orderByDirection == Order_By.Ascending)
                {
                    query.OrderBy(OrderBy);
                }
                else
                    query.OrderByDescending(OrderBy);
            }

            return query.ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);

            _context.SaveChanges();

            return entities;
        }


        public T Update(T entity)
        {
             _context.Update(entity);
           
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public void DeleteRange(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);

        }
        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public int Count()
        {
          return  _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Count(match);

        }
    }
}
