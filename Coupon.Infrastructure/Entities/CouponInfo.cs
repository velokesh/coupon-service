#region References
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#endregion

namespace Coupon.Infrastructure.Entities
{

    [Serializable]
    public class Coupons
    {
        public Coupons(List<Upc> upcs)
        {
            this.Upcs = upcs;
        }

        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("offr_id")]
        public string OfferId { get; set; }

        [BsonElement("mfr_cd")]
        public string? MfrCd { get; set; }

        [BsonElement("mfr_id")]
        public string? MfrId { get; set; }

        [BsonElement("min_qty")]
        public int? MinQty { get; set; }

        [BsonElement("offr_cd")]
        public string? OfferCd { get; set; }

        [BsonElement("tgt_typ")]
        public string? TgtType { get; set; }

        [BsonElement("visible")]
        public string? Visible { get; set; }

        [BsonElement("offr_gs1")]
        public string? OfferGs1 { get; set; }

        [BsonElement("offr_src")]
        public string? OfferSrc { get; set; }

        [BsonElement("offr_sum")]
        public string? OfferSum { get; set; }

        [BsonElement("offr_typ")]
        public string? OfferType { get; set; }

        [BsonElement("offr_upc")]
        public string? OfferUpc { get; set; }

        [BsonElement("create_dt")]
        public DateTime? CreateDt { get; set; }

        [BsonElement("brand_name")]
        public string? BrandName { get; set; }

        [BsonElement("offr_descr")]
        public string? OfferDesc { get; set; }

        [BsonElement("offr_img_1")]
        public string? OfferImg1 { get; set; }

        [BsonElement("offr_img_2")]
        public string? OfferImg2 { get; set; }

        [BsonElement("reward_qty")]
        public int? RewardQty { get; set; }

        [BsonElement("offr_act_dt")]
        public DateTime? OfferActDt { get; set; }

        [BsonElement("company_name")]
        public string? CompanyName { get; set; }

        [BsonElement("min_qty_desc")]
        public string? MinQtyDesc { get; set; }

        [BsonElement("offr_assn_cd")]
        public string? OfferAssnCd { get; set; }

        [BsonElement("activation_dt")]
        public DateTime? ActivationDt { get; set; }

        [BsonElement("offr_fine_prt")]
        public string? OfferFinePrt { get; set; }

        [BsonElement("redemption_dt")]
        public DateTime? RedemptionDt { get; set; }

        [BsonElement("source_act_dt")]
        public string? SourceActDt { get; set; }

        [BsonElement("source_exp_dt")]
        public string? SourceExpDt { get; set; }

        [BsonElement("min_trip_count")]
        public int? MinTripCount { get; set; }

        [BsonElement("offr_expiry_dt")]
        public DateTime? OfferExpiryDt { get; set; }

        [BsonElement("times_shop_qty")]
        public int? TimesShopQty { get; set; }

        [BsonElement("offr_disclaimer")]
        public string? OfferDisclaimer { get; set; }

        [BsonElement("offr_shutoff_dt")]
        public DateTime? OfferShutoffDt { get; set; }

        [BsonElement("pdt_offr_act_dt")]
        public DateTime? ProdtOffrActDt { get; set; }

        [BsonElement("redemption_freq")]
        public string? RedemptionFreq { get; set; }

        [BsonElement("category")]
        public Category? Category { get; set; }

        [BsonElement("min_basket_value")]
        public decimal? MinBasketValue { get; set; }

        [BsonElement("reward_offer_val")]
        public decimal? RewardOfferVal { get; set; }

        [BsonElement("clearing_house_id")]
        public string? ClearingHouseId { get; set; }

        [BsonElement("is_auto_activated")]
        public int? IsAutoActivated { get; set; }

        [BsonElement("offr_featured_txt")]
        public string? OfferFeaturedTxt { get; set; }

        [BsonElement("source_pdt_act_dt")]
        public DateTime? SourceProdtActDt { get; set; }

        [BsonElement("source_pdt_exp_dt")]
        public DateTime? SourceProdtExpDt { get; set; }

        [BsonElement("source_shutoff_dt")]
        public DateTime? SourceShutoffDt { get; set; }

        [BsonElement("pdt_offr_expiry_dt")]
        public DateTime? ProdtOffrExpiryDt { get; set; }

        [BsonElement("clearing_house_name")]
        public string? ClearingHouseName { get; set; }

        [BsonElement("redemption_limit_qty")]
        public int? RedemptionLimitQty { get; set; }

        [BsonElement("reward_catagory_name")]
        public string? RewardCatagoryName { get; set; }

        [BsonElement("upcs")]
        public List<Upc> Upcs { get; set; }

        public int SortNum { get; set; }
    }

    [Serializable]
    public class Upc
    {
        [BsonElement("upc")]
        public string? UpcNum { get; set; }
    }
}

