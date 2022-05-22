using Albumapp.Models.Interfaces;
namespace Albumapp.Models
{
    public class Photo : IPhoto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }        
    }
}
