using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDiary.API.Data;
using GameDiary.API.Models;

namespace GameDiary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ReviewsController(AppDbContext db)
        {
            _db = db;
        }

        // POST /api/reviews — добавить отзыв к игре
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            var game = await _db.Games.FindAsync(review.GameId);
            if (game == null) return NotFound("Игра не найдена");

            review.CreatedAt = DateTime.Now;
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();
            return Ok(review);
        }

        // GET /api/reviews/game/5 — все отзывы одной игры
        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetByGame(int gameId)
        {
            var reviews = await _db.Reviews
                                   .Where(r => r.GameId == gameId)
                                   .ToListAsync();
            return Ok(reviews);
        }

        // DELETE /api/reviews/5 — удалить отзыв
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            if (review == null) return NotFound("Отзыв не найден");

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
            return Ok("Отзыв удалён");
        }
    }
}