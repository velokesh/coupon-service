using Coupon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public interface IQuotientSearchable
    {
        /// <summary>
        /// Gets the NumberOfPageRecords
        /// </summary>
        int NumberOfPageRecords { get; set; }

        /// <summary>
        /// Gets the PageIndex
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// Gets the SortByType
        /// </summary>
        SortByType? SortByType { get; set; }

        /// <summary>
        /// Gets the SortOrderType
        /// </summary>
        SortOrderType SortOrderType { get; set; }

        /// <summary>
        /// Gets a list of all coupon filters
        /// </summary>
        IEnumerable<CouponFilter> Filters { get; set; }

        ContextAttributes ContextAttributes { get; set; }
    }
}
