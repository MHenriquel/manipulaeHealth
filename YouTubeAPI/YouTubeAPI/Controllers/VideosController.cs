using Microsoft.AspNetCore.Mvc;
using YouTubeAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class VideosController : ControllerBase
{
    private readonly YouTubeDbContext _context;

    public VideosController(YouTubeDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetVideos([FromQuery] string title, [FromQuery] string author, [FromQuery] DateTime? publishedAfter, [FromQuery] string q)
    {
        var videosQuery = _context.Videos.AsQueryable();

        if (!string.IsNullOrEmpty(title))
            videosQuery = videosQuery.Where(v => v.Title.Contains(title));
        if (!string.IsNullOrEmpty(author))
            videosQuery = videosQuery.Where(v => v.Author.Contains(author));
        if (publishedAfter.HasValue)
            videosQuery = videosQuery.Where(v => v.PublishedAt >= publishedAfter.Value);
        if (!string.IsNullOrEmpty(q))
            videosQuery = videosQuery.Where(v => v.Description.Contains(q) || v.Title.Contains(q) || v.Channel.Contains(q));

        return Ok(videosQuery.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> InsertVideo([FromBody] Video video)
    {
        if (video == null)
            return BadRequest();

        _context.Videos.Add(video);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVideos), new { id = video.Id }, video);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVideo(int id, [FromBody] Video updatedVideo)
    {
        var video = await _context.Videos.FindAsync(id);

        if (video == null)
            return NotFound();

        video.Title = updatedVideo.Title;
        video.Description = updatedVideo.Description;
        video.Duration = updatedVideo.Duration;
        video.VideoUrl = updatedVideo.VideoUrl;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideo(int id)
    {
        var video = await _context.Videos.FindAsync(id);

        if (video == null)
            return NotFound();

        video.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
