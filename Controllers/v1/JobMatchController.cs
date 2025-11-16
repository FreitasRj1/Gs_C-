using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkFutures.Api.Data;
using WorkFutures.Api.Models;

namespace WorkFutures.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class JobMatchesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public JobMatchesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.JobMatches.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jm = await _db.JobMatches.FindAsync(id);
            if (jm == null) return NotFound();
            return Ok(jm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobMatch model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.JobMatches.Add(model);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get),
                new { id = model.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() },
                model);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] JobMatch model)
        {
            if (id != model.Id) return BadRequest("ID diferente do corpo da requisição.");
            if (!await _db.JobMatches.AnyAsync(x => x.Id == id)) return NotFound();

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var jm = await _db.JobMatches.FindAsync(id);
            if (jm == null) return NotFound();

            _db.JobMatches.Remove(jm);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
