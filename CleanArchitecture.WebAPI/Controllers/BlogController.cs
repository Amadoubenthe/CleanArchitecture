using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Blog blog)
        {
            var createdBlog = await _blogService.AddAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            try
            {
                var b = _blogService.UpdateAsync(id, blog);
                return Ok(b);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        /// Modifier un Role et ses permissions par son Identifiant
        ///</summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRoleAsync(string id, [FromBody] RoleRequest request)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(new Response(false, "données non valides"));

        //        var result = await _roleService.UpdateRoleAsync(id, request);
        //        return result.Data != null ? Ok(result) : NotFound(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new Response(false, ex.Message));
        //    }

        //}
    }
}
