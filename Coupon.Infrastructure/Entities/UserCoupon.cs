using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coupon.Infrastructure.Entities
{
    public class UserCoupon
    {
        [Key]
        [Column("OFFR_ID")]
        public string OfferId { get; set; } = null!;

        [Column("CUST_ID")]
        public int CustomerId { get; set; }

        [Column("IS_ACTIVE")]
        public int IsActive { get; set; }

        [Column("IS_CLIPPED")]
        public int IsClipped { get; set; }

        [Column("CREATE_DT")]
        public DateTime CreatedDate { get; set; }

        [Column("BATCH_ID")]
        public int BatchId { get; set; }

        [Column("SORT_NUM")]
        public int SortNumber { get; set; }

        [Column("CLIPPED_DT")]
        public DateTime ClippedDate { get; set; }

        [Column("DEVICE_GUID")]
        public string? DeviceGuid { get; set; }

        [Column("COUPON_OFFR_TYP_ID")]
        public int CouponOfferTypeId { get; set; }

        [Column("OFFR_VARIANT")]
        public string? OfferVariant { get; set; }

        [Column("COUPON_CLIPPED_DT")]
        public DateTime CouponClippedDate { get; set; }

    }
}
