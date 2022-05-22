using Albumapp.DataAccess.RestServices.Interfaces;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Albumapp.DataAccess.RestServices
{
    public class ExternalClientServices: IExternalClientServices
    {
        private readonly IRestClient _restClient;

        public ExternalClientServices(IRestClient restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// Execute Get Rest Request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<IRestResponse> ExecuteGetAsync(string url)
        {
            _restClient.BaseUrl = new Uri(url);
            var restRequest = new RestRequest(Method.GET);
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            _restClient.ExecuteAsync(restRequest, (response) => taskCompletionSource.SetResult(response));
            return taskCompletionSource.Task;
        }

    }
}
