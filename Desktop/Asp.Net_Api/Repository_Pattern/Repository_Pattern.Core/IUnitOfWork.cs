using Repository_Pattern.Core.Interfaces;
using Repository_Pattern.Core.Models;

namespace Repository_Pattern.Core
{
    public interface IUnitOfWork:IDisposable
    {
        public IBooksRepository Books { get; }
        public IBaseRepository<Author> Authors { get; }

        public int Complete();

    }
}
