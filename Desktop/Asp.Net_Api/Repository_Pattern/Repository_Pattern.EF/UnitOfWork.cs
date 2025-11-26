using Repository_Pattern.Core;
using Repository_Pattern.Core.Interfaces;
using Repository_Pattern.Core.Models;
using Repository_Pattern.EF.Repositories;

namespace Repository_Pattern.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _context ;

        public IBooksRepository Books {  get;private set; }

        public IBaseRepository<Author> Authors {  get;private set; }

        public UnitOfWork(ApplicationDbcontext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
            Books = new BooksRepository(_context);
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
