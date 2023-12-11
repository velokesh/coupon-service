using Coupon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{

    public class CouponSearch 
    {
        /// <summary>
        /// Gets the number of page records
        /// </summary>
        public int NumPageRecords { get; set; }

        /// <summary>
        /// Gets the page index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets the sort by type
        /// </summary>
        public SortByType? SortByType { get; set; }

        /// <summary>
        /// Gets the sort order type
        /// </summary>
        public SortOrderType SortOrderType { get; set; } = SortOrderType.Ascending;


        /// <summary>
        /// Specify if the we need to get coupons,cashback or both
        /// </summary>
        public OfferSourceType OfferSourceType { get; set; } = OfferSourceType.Coupon;

        /// <summary>
        /// Used to specify the mixmode between coupons and cashback (couponsfirst,cashbackfirst,comingled, see MixMiode enum for details)
        /// </summary>
        public MixMode MixMode { get; set; } = MixMode.Mix1;

        /// <summary>
        /// Always return all categories and brands regardless of filter or search parameters.
        /// </summary>
        public bool DisplayAllCategoriesAndBrands { get; set; } = false;

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
    }
}
