using Repository_Pattern.Core.Interfaces;
using Repository_Pattern.Core.Models;
 
namespace Repository_Pattern.EF.Repositories
{
    public class BooksRepository: BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbcontext _context;
        public BooksRepository(ApplicationDbcontext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<Book> SpecialMethod()
        {
            return _context.Books.ToList();
        }
    }
}
