namespace Narochno.Steam.Entities.Requests
{
    public class GetReviewsRequest
    {
        public GetReviewsRequest(uint appId)
        {
            AppId = appId;
        }

        public ReviewFilter Filter { get; set; }
        public string Language { get; set; } = "all";
        public uint? DayRange { get; set; }
        public uint? StartOffset { get; set; }
        public ReviewType ReviewType { get; set; }
        public ReviewPurchaseType PurchaseType { get; set; }

        public uint AppId { get; set; }
    }
}
