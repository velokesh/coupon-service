using Coupon.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public sealed class CouponFilterRequest
    {
        private string _category;
        /// <summary>
        /// Default constructor
        /// </summary>
        public CouponFilterRequest()
        {
            StoreNumber = -1;
            OfferIdList = new List<string>();
            UpcList = new List<string>();
        }

        /// <summary>
        /// Categories list
        /// </summary>
        [JsonProperty(PropertyName = "Categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Brands list
        /// </summary>
        [JsonProperty(PropertyName = "Brands")]
        public List<string> Brands { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        [JsonProperty(PropertyName = "CategoryName")]
        public string CategoryName
        {
            get
            {

                return _category;
            }

            set
            {
                _category = value;
                Categories = new List<string>();
                Categories.Add(_category);

            }
        }


        /// <summary>
        /// Coupon description
        /// </summary>
        [JsonProperty(PropertyName = "CouponDescription")]
        public string CouponDescription { get; set; }

        /// <summary>
        /// Store number
        /// </summary>
        [JsonProperty(PropertyName = "StoreNumber")]
        public int StoreNumber { get; set; }

        /// <summary>
        /// Offer id collection
        /// </summary>
        [JsonProperty(PropertyName = "OfferIdList")]
        public List<string> OfferIdList { get; set; }

        /// <summary>
        /// UPC/SKU collection
        /// </summary>
        [JsonProperty(PropertyName = "UpcList")]
        public List<string> UpcList { get; set; }

        /// <summary>
        /// Search text
        /// </summary>
        [JsonProperty(PropertyName = "SearchText")]
        public string SearchText { get; set; }

        /// <summary>
        /// Application mode (old/new)
        /// </summary>
        [JsonProperty(PropertyName = "FilterType")]
        public CouponApplicationMode ApplicationMode { get; set; }

        /// <summary>
        /// Coupon SubType (Coupon, CashBack, None)
        /// </summary>
        [JsonProperty(PropertyName = "OfferSourceType")]
        public OfferSourceType OfferSourceType { get; set; } = OfferSourceType.Coupon;

        /// <summary>
        /// Always return all categories and brands regardless of filter or search parameters.
        /// </summary>
        [JsonProperty(PropertyName = "displayAllCategoriesAndBrands")]
        public bool DisplayAllCategoriesAndBrands { get; set; } = false;

        [JsonProperty(PropertyName = "MixMode")]
        public MixMode MixMode { get; set; } = MixMode.Mix1;

        /// <summary>
        /// Sort order
        /// </summary>
        [JsonProperty(PropertyName = "SortOrder")]
        public SortOrderType SortOrder { get; set; } = SortOrderType.Ascending;

        /// <summary>
        /// Sort by
        /// </summary>
        [JsonProperty(PropertyName = "SortBy")]
        public SortByType? SortBy { get; set; } = null;

        /// <summary>
        /// Page index
        /// </summary>
        [JsonProperty(PropertyName = "PageIndex")]
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// Number of records per page
        /// </summary>
        [JsonProperty(PropertyName = "NumPageRecords")]
        public int NumPageRecords { get; set; } = 0;
    }
}
