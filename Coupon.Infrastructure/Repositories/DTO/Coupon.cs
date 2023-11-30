namespace Coupon.Infrastructure.Repositories.DTO
{
    public class Coupon
    {
        public Coupon() { 
            Upcs = [];
        }

        public string OfferId { get; set; } = null!;
        public string OfferImg1 { get; set; } = null!;
        public string OfferImg2 { get; set; } = null!;
        public string OfferType { get; set; } = null!;
        public string RedemptionFreq { get; set; } = null!;
        public string OfferUpc { get; set; } = null!;
        public string OfferGs1 { get; set; } = null!;
        public string OfferCd { get; set; } = null!;
        public DateTime OfferActDt { get; set; }
        public DateTime OfferExpiryDt { get; set; }
        public string OfferDesc { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string MfrCd { get; set; } = null!;
        public string MfrId { get; set; } = null!;
        public string OfferSum { get; set; } = null!;
        public string OfferFinePrt { get; set; } = null!;
        public string OfferDisclaimer { get; set; } = null!;
        public string OfferFeaturedTxt { get; set; } = null!;
        public string OfferSrc { get; set; } = null!;
        public bool? IsAutoActivated { get; set; }
        public string TgtType { get; set; } = null!;
        public string Visible { get; set; } = null!;
        public DateTime ActivationDt { get; set; }
        public DateTime RedemptionDt { get; set; }
        public string OfferAssnCd { get; set; } = null!;
        public int? RedemptionLimitQty { get; set; }
        public decimal? MinBasketValue { get; set; }
        public int? MinTripCount { get; set; }
        public int? TimesShopQty { get; set; }
        public int? MinQty { get; set; }
        public string MinQtyDesc { get; set; } = null!;
        public decimal? RewardOfferVal { get; set; }
        public string RewardCatagoryName { get; set; } = null!;
        public int? RewardQty { get; set; }
        public string ClearingHouseId { get; set; } = null!;
        public string ClearingHouseName { get; set; } = null!;
        public DateTime OfferShutoffDt { get; set; }
        public DateTime ProdtOffrActDt { get; set; }
        public DateTime ProdtOffrExpiryDt { get; set; }
        public DateTime CreateDt { get; set; }
        public string SourceActDt { get; set; } = null!;
        public string SourceExpDt { get; set; } = null!;
        public string SourceShutoffDt { get; set; } = null!;
        public string SourceProdtActDt { get; set; } = null!;
        public string SourceProdtExpDt { get; set; } = null!;

        public List<CouponUpc> Upcs { get; set; }
    }
}
