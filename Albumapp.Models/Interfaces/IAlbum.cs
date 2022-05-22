namespace Albumapp.Models.Interfaces
{
    public interface IAlbum: IBase
    {
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}