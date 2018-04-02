using Narochno.Steam.Entities.Requests;
using Narochno.Steam.Entities.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Narochno.Steam
{
    public interface ISteamClient
    {
        Task<GetReviewsResponse> GetReviews(GetReviewsRequest request, CancellationToken token = default(CancellationToken));
        Task<GetAppsResponse> GetApps(CancellationToken token = default(CancellationToken));
        Task<GetNewsResponse> GetNews(GetNewsRequest request, CancellationToken token = default(CancellationToken));
    }
}