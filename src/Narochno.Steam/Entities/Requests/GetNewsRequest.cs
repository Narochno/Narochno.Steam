using System;

namespace Narochno.Steam.Entities.Requests
{
    public class GetNewsRequest
    {
        public GetNewsRequest(uint appId)
        {
            AppId = appId;
        }

        public uint AppId { get; set; }
        public uint? MaxLength { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public uint? Count { get; set; }
    }
}
