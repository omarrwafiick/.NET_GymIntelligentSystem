using ApplicationLayer.Contracts;
using DomainLayer.Contracts;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrastructureLayer.Implementations.Repositories
{
    public class ApplicationRepository<T> where T : class ,IApplicationRepository<T>, IMainEntity
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> condtion)
            => await _context.Set<T>().Where(condtion).ToListAsync();

        public async Task<T> GetAsync(Guid id)
            => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> condtion)
            => await _context.Set<T>().Where(condtion).SingleOrDefaultAsync();

        public async Task<bool> CreateAsync(T Entity)
        {
            await _context.AddAsync(Entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
         
        public async Task<bool> UpdateAsync(T Entity)
        {
            _context.Update(Entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(T Entity)
        {
            _context.Remove(Entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
