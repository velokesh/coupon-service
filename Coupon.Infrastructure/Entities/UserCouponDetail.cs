#region References
using MongoDB.Bson.Serialization.Attributes;
#endregion

namespace Coupon.Infrastructure.Entities
{
    [Serializable]
    public class UserCouponDetail
    {
        [BsonElement("OFFR_ID")]
        public string OfferId { get; set; } = null!;

        [BsonElement("IS_ACTIVE")]
        public int IsActive { get; set; }

        [BsonElement("IS_CLIPPED")]
        public int IsClipped { get; set; }

        [BsonElement("CREATE_DT")]
        public DateTime CreateDt { get; set; }

        [BsonElement("BATCH_ID")]
        public int BatchId { get; set; }

        [BsonElement("SORT_NUM")]
        public int SortNum { get; set; }

        [BsonElement("CLIPPED_DT")]
        public string? ClippedDt { get; set; }

        [BsonElement("DEVICE_GUID")]
        public string? DeviceGuid { get; set; }

        [BsonElement("COUPON_OFFR_TYP_ID")]
        public int CouponOfferTypeId { get; set; }

        [BsonElement("OFFR_VARIANT")]
        public string? OfferVariant { get; set; }

        [BsonElement("COUPON_CLIPPED_DT")]
        public DateTime CouponClippedDt { get; set; }
    }
}
