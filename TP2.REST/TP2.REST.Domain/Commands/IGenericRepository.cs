
namespace TP2.REST.Domain.Commands
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : class;
    }
}
