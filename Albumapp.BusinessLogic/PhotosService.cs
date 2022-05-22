using Albumapp.BusinessLogic.Interfaces;
using Albumapp.DataAccess.RestServices.Interfaces;
using Albumapp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albumapp.BusinessLogic
{
    public class PhotosService : IPhotosService
    {
        #region Declaration
               
        private readonly IExternalClientServices _externalClientServices;

        //TODO: it's good to read url from appsettings
        public string PhotosApiUrl { get; set; } = "http://jsonplaceholder.typicode.com/photos";

        //TODO: it's good to read url from appsettings
        public string AlbumApiUrl { get; set; } = "http://jsonplaceholder.typicode.com/albums";

        //TODO: Read Album Count from API request or AppSettings
        public int AlbumCount { get; set; } = 5;

        public PhotosService(IExternalClientServices externalClientServices)
        {
            _externalClientServices = externalClientServices;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<List<AlbumPhotos>> Get()
        {
            return await Merge(0);
        }

        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<AlbumPhotos>> Get(int userId)
        {
            return await Merge(userId);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Merges this instance.
        /// </summary>
        /// <returns></returns>
        private async Task<List<AlbumPhotos>> Merge(int userId)
        {
            //1. Read Albums from endpoint
            var AlbumApiresult = await _externalClientServices.ExecuteGetAsync(AlbumApiUrl);
            var albumList = JsonConvert.DeserializeObject<List<AlbumPhotos>>(AlbumApiresult.Content);
            
            if(userId>0)
                albumList= albumList.Where(p => p.UserId == userId).ToList();

            //In order to increase performance or buden on API, It's good way to pull all data. 
            //so i implement take top records.
            //It's better way to read album count from API request or AppSettings
            albumList = albumList.Take(AlbumCount).ToList();

            //2. Read Photos from endpoint
            var photosApiresult = await  _externalClientServices.ExecuteGetAsync(PhotosApiUrl);
            var photosList = JsonConvert.DeserializeObject<List<Photo>>(photosApiresult.Content);

            //3.Merge
            albumList.ForEach(p => p.Photos = photosList.Where(q => q.AlbumId == p.Id).ToList());            
            return albumList;
        }
        #endregion

    }
}
