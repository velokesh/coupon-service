namespace Coupon.Domain.Models
{
    public class FilteredCoupon
    {
        public FilteredCoupon()
        {
            Coupons = new List<BaseCoupon>();
            //   PersonalizedOffers = new List<IPersonalizedOffer>();
            Category = new List<CouponCategory>();
            Brands = new List<CouponBrand>();
            PaginationInfo = new CouponPagination();
        }
       
        public CouponPagination PaginationInfo { get; set; }

        public List<BaseCoupon> Coupons { get; set; }

    
        public List<CouponCategory> Category { get; set; }

        public List<CouponBrand> Brands { get; set; }

    }
}
