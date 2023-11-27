using Coupon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class CouponSearch : IQuotientSearchable
    {
        /// <summary>
        /// Gets the number of page records
        /// </summary>
        public int NumberOfPageRecords { get; set; }

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
        public SortOrderType SortOrderType { get; set; }

        /// <summary>
        /// Gets a list of all coupon filters
        /// </summary>
        public IEnumerable<CouponFilter> Filters { get; set; }

        public ContextAttributes ContextAttributes { get; set; }

        /// <summary>
        /// Specify if the we need to get coupons,cashback or both
        /// </summary>
        public OfferSourceType OfferSourceType { get; set; }

        /// <summary>
        /// Used to specify the mixmode between coupons and cashback (couponsfirst,cashbackfirst,comingled, see MixMiode enum for details)
        /// </summary>
        public MixMode MixMode { get; set; }

        /// <summary>
        /// Always return all categories and brands regardless of filter or search parameters.
        /// </summary>
        public bool DisplayAllCategoriesAndBrands { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfPageRecords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortByType"></param>
        /// <param name="sortOrderType"></param>
        public CouponSearch(int numberOfPageRecords, int pageIndex, SortByType? sortByType, SortOrderType sortOrderType)
        {
            NumberOfPageRecords = numberOfPageRecords;
            PageIndex = pageIndex;
            SortByType = sortByType;
            SortOrderType = sortOrderType;
        }

        /// <summary>
        /// Constructor with filters
        /// </summary>
        /// <param name="numberOfPageRecords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortByType"></param>
        /// <param name="sortOrderType"></param>
        /// <param name="filters"></param>
        //public CouponSearch(int numberOfPageRecords, int pageIndex, SortByType sortByType, SortOrderType sortOrderType, IEnumerable<CouponFilter> filters, ContextAttributes context = null)
        //{
        //    NumberOfPageRecords = numberOfPageRecords;
        //    PageIndex = pageIndex;
        //    SortByType = sortByType;
        //    SortOrderType = sortOrderType;
        //    Filters = filters;
        //    ContextAttributes = context;

        //}
    }
}
