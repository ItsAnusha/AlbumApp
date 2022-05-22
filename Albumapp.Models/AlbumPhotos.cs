using Albumapp.Models.Interfaces;
using System.Collections.Generic;

namespace Albumapp.Models
{
    public class AlbumPhotos : IAlbum
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}