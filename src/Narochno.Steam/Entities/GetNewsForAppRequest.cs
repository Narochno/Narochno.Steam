using System;

namespace Narochno.Steam.Entities
{
    public class GetNewsForAppRequest
    {
        public GetNewsForAppRequest(int appId)
        {
            AppId = appId;
        }

        public int AppId { get; set; }
        public int? MaxLength { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public int? Count { get; set; }
    }
}
