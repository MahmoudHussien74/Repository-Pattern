using System.Linq.Expressions;

namespace Repository_Pattern.Core.Interfaces
{
    public interface IBaseRepository<T>where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);   

        IEnumerable<T> GetAll();

        T Find(Expression<Func<T, bool>> match, string[] includes = null!);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null!);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match,int take ,int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match,int? take,int? skip,
          Expression<Func<T,object>>OrderBy = null,string orderByDirection = "ASC");

        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);

        void Attach (T entity);

        int Count();

        int Count(Expression<Func<T, bool>> match);

    }
}
