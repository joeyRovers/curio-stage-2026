using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstNewDatabaseSample.Data;
using CodeFirstNewDatabaseSample.Models;

namespace CodeFirstNewDatabaseSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BloggingContext _db;

        public BlogsController(BloggingContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> Get()
            => await _db.Blogs.Include(b => b.Posts).ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var blog = await _db.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.BlogId == id);
            if (blog == null) return NotFound();
            return blog;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> Post(Blog model)
        {
            _db.Blogs.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.BlogId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Blog model)
        {
            if (id != model.BlogId) return BadRequest();

            _db.Entry(model).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BlogExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            _db.Blogs.Remove(blog);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        private bool BlogExists(int id) => _db.Blogs.Any(b => b.BlogId == id);
    }
}