namespace YouTubeAPI.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }
        public int Duration { get; set; } // em segundos
        public string VideoUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime PublishedAt { get; set; }
    }
}
