using Albumapp.BusinessLogic.Interfaces;
using Albumapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albumapp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        #region Declaration
                
        private readonly ILogger<AlbumsController> _logger;

        private readonly IPhotosService _photosService;

        public AlbumsController(ILogger<AlbumsController> logger, IPhotosService photosService)
        {
            _logger = logger;
            _photosService = photosService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<AlbumPhotos>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AlbumPhotos>))]
        public async Task<ActionResult<IEnumerable<AlbumPhotos>>> Get()
        {
            try
            {
                var result = await _photosService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //TODO: Implement Logging
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        /// <summary>
        /// Gets the albums by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("{userId}", Name = "GetAlbumsByUserId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<AlbumPhotos>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AlbumPhotos>))]
        public async Task<ActionResult<IEnumerable<AlbumPhotos>>> GetAlbumsByUserId(int userId)
        {
            try
            {
                if (userId <= 0)
                    return BadRequest("Invalid User Id");

                var result = await _photosService.Get(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //TODO: Implement Logging
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #endregion

    }
}
