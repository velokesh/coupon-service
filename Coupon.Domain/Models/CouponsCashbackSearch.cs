using Coupon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class CouponsCashbackSearch : CouponSearch
    {

        private const string MY_COUPONS_CATEGORY = "My Coupons";

        public CouponsCashbackSearch(int numberOfPageRecords, int pageIndex, SortByType? sortByType, SortOrderType sortOrderType) : base(numberOfPageRecords, pageIndex, sortByType, sortOrderType)
        {
        }
        /// <summary>
        /// Upcs list
        /// </summary>
        public List<string> UpcList { get; set; }

        /// <summary>
        /// Categories list
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Brands list
        /// </summary>
        public List<string> Brands { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Store number
        /// </summary>
        public int StoreNumber { get; set; } = -1;

        public bool IncludeClippedCategories { get; set; }

        public bool IsMyCouponsSearch()
        {
            return Categories?.FirstOrDefault() == MY_COUPONS_CATEGORY;
        }


    }
}
