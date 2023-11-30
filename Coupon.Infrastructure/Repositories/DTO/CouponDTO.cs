namespace Coupon.Infrastructure.Repositories.DTO
{
    public class CouponDTO
    {
        public CouponDTO() { 
            Upcs = [];
        }

        public string OfferId { get; set; } = null!;
        public string? OfferImg1 { get; set; } 
        public string? OfferImg2 { get; set; } 
        public string? OfferType { get; set; } 
        public string? RedemptionFreq { get; set; } 
        public string? OfferUpc { get; set; } 
        public string? OfferGs1 { get; set; } 
        public string? OfferCd { get; set; } 
        public DateTime? OfferActDt { get; set; }
        public DateTime? OfferExpiryDt { get; set; }
        public string? OfferDesc { get; set; } 
        public string? BrandName { get; set; } 
        public string? CompanyName { get; set; } 
        public string? MfrCd { get; set; } 
        public string? MfrId { get; set; } 
        public string? OfferSum { get; set; } 
        public string? OfferFinePrt { get; set; } 
        public string? OfferDisclaimer { get; set; } 
        public string? OfferFeaturedTxt { get; set; } 
        public string? OfferSrc { get; set; } 
        public bool? IsAutoActivated { get; set; }
        public string? TgtType { get; set; } 
        public string? Visible { get; set; } 
        public DateTime? ActivationDt { get; set; }
        public DateTime? RedemptionDt { get; set; }
        public string? OfferAssnCd { get; set; } 
        public int? RedemptionLimitQty { get; set; }
        public decimal? MinBasketValue { get; set; }
        public int? MinTripCount { get; set; }
        public int? TimesShopQty { get; set; }
        public int? MinQty { get; set; }
        public string? MinQtyDesc { get; set; } 
        public decimal? RewardOfferVal { get; set; }
        public string? RewardCatagoryName { get; set; } 
        public int? RewardQty { get; set; }
        public string? ClearingHouseId { get; set; } 
        public string? ClearingHouseName { get; set; } 
        public DateTime? OfferShutoffDt { get; set; }
        public DateTime? ProdtOffrActDt { get; set; }
        public DateTime? ProdtOffrExpiryDt { get; set; }
        public DateTime? CreateDt { get; set; }
        public string? SourceActDt { get; set; } 
        public string? SourceExpDt { get; set; } 
        public string? SourceShutoffDt { get; set; } 
        public string? SourceProdtActDt { get; set; } 
        public string? SourceProdtExpDt { get; set; } 

        public List<CouponUpc> Upcs { get; set; }
    }
}
