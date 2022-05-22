namespace Albumapp.Models.Interfaces
{
    public interface IPhoto: IBase
    {        
        int AlbumId { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        string ThumbnailUrl { get; set; }
    }
}