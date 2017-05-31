using Narochno.Steam.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Narochno.Steam
{
    public interface ISteamClient : IDisposable
    {
        Task<GetAppListResponse> GetAppList(CancellationToken ctx = default(CancellationToken));
        Task<GetNewsForAppResponse> GetNewsForApp(GetNewsForAppRequest request, CancellationToken ctx = default(CancellationToken));
    }
}