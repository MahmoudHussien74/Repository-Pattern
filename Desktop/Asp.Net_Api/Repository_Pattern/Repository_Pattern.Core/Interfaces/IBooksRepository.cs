using Repository_Pattern.Core.Models;

namespace Repository_Pattern.Core.Interfaces
{
    public interface IBooksRepository:IBaseRepository<Book>
    {

        IEnumerable<Book> SpecialMethod();

    }
}
