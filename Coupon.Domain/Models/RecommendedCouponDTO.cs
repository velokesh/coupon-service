﻿using Coupon.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class RecommendedCouponDTO
    {

        private string _category;
        /// <summary>
        /// The user session token
        /// </summary>
        //[JsonProperty(PropertyName = "UserSessionToken")]
        //public string UserSessionToken { get; set; }

        /// <summary>
        /// Page index
        /// </summary>
       
        public int PageIndex { get; set; }

        /// <summary>
        /// Number of records per page
        /// </summary>
        
        public int NumPageRecords { get; set; }

        
        /// <summary>
        /// Category name
        /// </summary>
        public string CategoryName
        {
            get
            {

                return _category;
            }

            set
            {
                _category = value;

                if (Categories?.Any() != true && !string.IsNullOrEmpty(_category))
                {
                    Categories = new List<string>();
                    Categories.Add(_category);
                }


            }
        }


        /// <summary>
        /// Sort by
        /// </summary>
        public SortByType SortBy { get; set; }

        /// <summary>
        /// Sort order
        /// </summary>
        [JsonProperty(PropertyName = "SortOrder")]
        public SortOrderType SortOrder { get; set; }

        /// <summary>
        /// FilterType -- ToDo
        /// </summary>
        [JsonProperty(PropertyName = "FilterType")]
        public CouponApplicationMode ApplicationMode { get; set; }

        /// <summary>
        /// IncludeClippedCategories
        /// </summary>
        //[JsonProperty(PropertyName = "IncludeClippedCategories")]
        public bool IncludeClippedCategories { get; set; }

        /// <summary>
        /// Coupon SubType (Coupon, CashBack, None)
        /// </summary>
       // [JsonProperty(PropertyName = "OfferSourceType")]
        public OfferSourceType OfferSourceType { get; set; }

        /// <summary>
        /// Always return all categories and brands regardless of filter or search parameters.
        /// </summary>
      //  [JsonProperty(PropertyName = "displayAllCategoriesAndBrands")]
        public bool DisplayAllCategoriesAndBrands { get; set; } = false;

        //[JsonProperty(PropertyName = "MixMode")]
        public MixMode MixMode { get; set; }

        /// <summary>
        /// Categories list
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Brands list
        /// </summary>
        public List<string> Brands { get; set; }
    }

}
