using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkFutures.Api.Data;
using WorkFutures.Api.Models;

namespace WorkFutures.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CandidatesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.Candidates.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var c = await _db.Candidates.FindAsync(id);
            if (c == null) return NotFound();
            return Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Candidate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Candidates.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new { id = model.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() },
                model);
        }
 
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Candidate model)
        {
            if (id != model.Id) return BadRequest("ID diferente do corpo da requisição.");
            if (!await _db.Candidates.AnyAsync(x => x.Id == id)) return NotFound();

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var c = await _db.Candidates.FindAsync(id);
            if (c == null) return NotFound();

            _db.Candidates.Remove(c);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
