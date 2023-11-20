using System.Linq.Expressions;

namespace TicTacToe.Database.Repositories
{
    public interface IBaseRepository<T> where T : new()
    {
        Task DeleteItem(int id);
        Task<T> GetItem(int id);
        Task<List<T>> GetItems();
        Task<T> UpdateItem(T item);
        Task<T> SaveItem(T item);
        Task SaveItems(List<T> items);
        Task<List<T>> GetItems(Expression<Func<T, bool>> predicate);
    }
}
