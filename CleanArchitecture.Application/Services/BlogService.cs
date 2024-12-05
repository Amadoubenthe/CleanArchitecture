using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class BlogService : IBlogService
    {
        public IBlogRepository _blogRepository { get; }
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            return await _blogRepository.AddAsync(blog);
        }

        public async Task<Blog> DeleteAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task<Blog> UpdateAsync(int id, Blog blog)
        {
            return await _blogRepository.UpdateAsync(id, blog);
        }
    }
}
