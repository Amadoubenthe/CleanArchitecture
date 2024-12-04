using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Services
{
    public interface IBlogServices
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> AddAsync(Blog blog);
        Task<Blog> UpdateAsync(int id, Blog blog);
        Task<Blog> DeleteAsync(int id);
    }
}
