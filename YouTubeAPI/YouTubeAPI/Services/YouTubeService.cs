using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using YouTubeAPI.Models;
using System.Linq;

namespace YouTubeAPI.Services
{
    public class YouTubeService
    {
        private readonly YouTubeService _youtubeService;
        private BaseClientService.Initializer initializer;

        public YouTubeService(BaseClientService.Initializer initializer)
        {
            this.initializer = initializer;
        }

        public YouTubeService(string apiKey)
        {
            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = GetType().ToString()
            });
        }

        public async Task<List<Video>> FetchVideosAsync()
        {
            //var request = _youtubeService.Search.List("snippet");
            //request.Q = "manipulação de medicamentos"; // Termo de pesquisa
            //request.RegionCode = "BR";
            //request.PublishedAfter = new DateTime(2025, 1, 1); // Apenas vídeos de 2025

            //var response = await request.ExecuteAsync();
            //var videos = response.Items.Select(item => new Video
            //{
            //    Title = item.Snippet.Title,
            //    Author = item.Snippet.ChannelTitle,
            //    Description = item.Snippet.Description,
            //    Channel = item.Snippet.ChannelId,
            //    VideoUrl = $"https://www.youtube.com/watch?v={item.Id.VideoId}",
            //    PublishedAt = item.Snippet.PublishedAt.Value
            //}).ToList();

            //return videos;
            return null;
        }

    }
}
