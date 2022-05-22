using Albumapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albumapp.BusinessLogic.Interfaces
{
    public  interface IPhotosService
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<List<AlbumPhotos>> Get();

        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<List<AlbumPhotos>> Get(int userId);
    }
}
