namespace Coupon.Infrastructure.Entities
{
    public class CouponUpc
    {
        public string OfferId { get; set; } = null!;

        public string Upc { get; set; }

        //public virtual CouponInfo Offer { get; set; } = null!;

        //public virtual Item UpcNavigation { get; set; } = null!;
    }
}