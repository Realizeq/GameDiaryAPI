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

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetByGame(int gameId)
        {
            var reviews = await _db.Reviews
                                   .Where(r => r.GameId == gameId)
                                   .ToListAsync();
            return Ok(reviews);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            if (review == null) return NotFound("Отзыв не найден");

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
            return Ok("Отзыв удалён");
        }

        [HttpPut("game/{gameId}")]
        public async Task<IActionResult> UpdateByGame(int gameId, [FromBody] Review updated)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(r => r.GameId == gameId);

            if (review == null)
            {
                updated.GameId = gameId;
                updated.CreatedAt = DateTime.Now;
                _db.Reviews.Add(updated);
            }
            else
            {
                review.Rating = updated.Rating;
                review.Comment = updated.Comment;
            }

            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}