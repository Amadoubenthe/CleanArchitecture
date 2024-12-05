using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;
        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();

            return blog;
        }

        public async Task<Blog> DeleteAsync(int id)
        {
            var existingBlog = await _blogDbContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == id);
            _blogDbContext.Blogs.Remove(existingBlog);
            await _blogDbContext.SaveChangesAsync();

            return existingBlog;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var existingBlog = await _blogDbContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == id);

            return existingBlog;
        }

        public async Task<Blog> UpdateAsync(int id, Blog blog)
        {
            var existingBlog = await _blogDbContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == id);

            existingBlog.Name = blog.Name;
            existingBlog.Description = blog.Description;
            existingBlog.Author = blog.Author;
            existingBlog.ImageUrl = blog.ImageUrl;

            return existingBlog;
        }
    }
}
