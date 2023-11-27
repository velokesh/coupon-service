using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //[JsonProperty("PaginationInfo")]
        public CouponPagination PaginationInfo { get; set; }

        public List<BaseCoupon> Coupons { get; set; }

      //  [JsonProperty("PersonalizedOffers", NullValueHandling = NullValueHandling.Ignore)]
      //  public List<IPersonalizedOffer> PersonalizedOffers { get; set; }

       // public Item Item { get; set; }


        // TODO change to categories but need coordinatino with UI for the backward cmompatibility
        //[JsonProperty("Category")]
        public List<CouponCategory> Category { get; set; }


       // [JsonProperty("Brands")]
        public List<CouponBrand> Brands { get; set; }


       // [JsonProperty("ClippedCategory", NullValueHandling = NullValueHandling.Ignore)]
       // public List<CouponCategory> ClippedCategories { get; set; }


    }
}
