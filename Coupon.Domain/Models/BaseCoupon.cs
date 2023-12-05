using Coupon.Domain.Enums;
using Newtonsoft.Json;

namespace Coupon.Domain.Models
{
    public class BaseCoupon
    {
        public int DiscountIndicator { get; set; }
        public CouponSource CouponType { get; set; }

        public OfferSourceType OfferSourceType { get; set; } 

        public List<long> UPCs { get; set; } = new List<long>();
        public string TargetType { get; set; }

        public string OfferCode { get; set; }

        public string OfferID { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string OfferType { get; set; }

        public int IsManufacturerCoupon { get; set; }

        public string RecemptionFrequency { get; set; }

        public DateTime OfferActivationDate { get; set; }

        public DateTime OfferExpirationDate { get; set; }

        public string OfferDescription { get; set; }

        public string OfferDisclaimer { get; set; }

        public string OfferFeaturedText { get; set; }

        public string BrandName { get; set; }

        public string Companyname { get; set; }

        public int TimesShopQuantity { get; set; }

        public int MinQuantity { get; set; }

        public string MinQuantityDescription { get; set; }

        public string OfferSummary { get; set; }

        public int IsAutoActivated { get; set; }

        public DateTime ActivationDate { get; set; }

        public string AssociationCode { get; set; }

        public int RedemptionLimitQuantity { get; set; }

        public decimal MinBasketValue { get; set; }

        public int MinTripCount { get; set; }

        public decimal RewaredOfferValue { get; set; }

        public string RewaredCategoryName { get; set; }

        public int RewardQuantity { get; set; }

        public int IsClipped { get; set; }
        public string Visible { get; set; }
        /// <summary>
        /// Counts the number of eligible products
        /// </summary>
        [JsonIgnore]
        public int UpcCount { get; set; }

        /// <summary>
        /// Checks whether the coupon has eligible products or not
        /// </summary>
        [JsonProperty(PropertyName = "isProductEligible")]
        public bool ProductEligible => UpcCount > 0;

        public string OfferToken { get; set; }

       // public Offer DGDiscount { get; set; }
       // [JsonIgnore]
       // public long? BetterOfferId { get; set; }

        [JsonProperty("expiryLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiryLabel { get; set; } = null;

        public bool IsCashback()
        {
            return OfferSourceType == OfferSourceType.Cashback;
        }

        [JsonIgnore]
        public int AppliedCount { get; set; }

        public bool IsBasketLevel { get; set; } = false;
    }
}
