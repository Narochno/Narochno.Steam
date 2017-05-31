using Narochno.Steam.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Narochno.Steam
{
    public interface ISteamClient : IDisposable
    {
        Task<GetNewsForAppResponse> GetNewsForApp(GetNewsForAppRequest request, CancellationToken ctx = default(CancellationToken));
    }
}