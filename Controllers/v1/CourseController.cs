using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkFutures.Api.Data;
using WorkFutures.Api.Models;

namespace WorkFutures.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public CoursesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _ctx.Courses.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            _ctx.Courses.Add(model);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), model);
        }
    }
}
