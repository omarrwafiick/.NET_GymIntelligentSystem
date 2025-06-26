
using DomainLayer.Contracts;
using System.Linq.Expressions;

namespace ApplicationLayer.Contracts
{
    public interface IApplicationRepository<T> where T : class, IMainEntity
    {
        Task<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> condtion);
        Task<bool> CreateAsync(T Entity);
        Task<bool> UpdateAsync(T Entity);
        Task<bool> DeleteAsync(T Entity);
    }
}
