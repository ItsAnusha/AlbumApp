using RestSharp;
using System.Threading.Tasks;

namespace Albumapp.DataAccess.RestServices.Interfaces
{
    public interface IExternalClientServices
    {
        /// <summary>
        /// Execute Get Rest Request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<IRestResponse> ExecuteGetAsync(string url);
    }
}
