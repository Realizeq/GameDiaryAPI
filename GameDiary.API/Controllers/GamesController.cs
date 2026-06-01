using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDiary.API.Data;
using GameDiary.API.Models;

namespace GameDiary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public GamesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _db.Games.Include(g => g.Reviews).ToListAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _db.Games.Include(g => g.Reviews)
                                      .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null) return NotFound("Игра не найдена");
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            game.AddedAt = DateTime.Now;
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Game updated)
        {
            var game = await _db.Games.FindAsync(id);
            if (game == null) return NotFound("Игра не найдена");

            game.Title = updated.Title;
            game.Platform = updated.Platform;
            game.Status = updated.Status;
            game.CoverImageUrl = updated.CoverImageUrl;

            await _db.SaveChangesAsync();
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _db.Games.FindAsync(id);
            if (game == null) return NotFound("Игра не найдена");

            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
            return Ok("Игра удалена");
        }
    }
}