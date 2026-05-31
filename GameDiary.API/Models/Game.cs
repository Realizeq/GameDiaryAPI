namespace GameDiary.API.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public DateTime AddedAt { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}