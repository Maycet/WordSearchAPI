namespace WordSearchAPI.Models
{
    public class WordSearchLog
    {
        public int Id { get; set; }
        public string? WordSearchContent { get; set; }
        public string? SearchedWord { get; set; }
        public bool Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}