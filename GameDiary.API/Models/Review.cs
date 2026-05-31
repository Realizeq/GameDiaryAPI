namespace GameDiary.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public Game Game { get; set; } = null!;
    }
}