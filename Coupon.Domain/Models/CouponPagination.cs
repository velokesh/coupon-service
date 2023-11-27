using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class CouponPagination
    {
        /// <summary>
        /// StartRecord property
        /// </summary>
        public int StartRecord { get; set; }

        /// <summary>
        /// ExpectedRecordsPerPage property
        /// </summary>
        public int ExpectedRecordsPerPage { get; set; }

        /// <summary>
        /// TotalRecordsPerPage property
        /// </summary>
        public int TotalRecordsPerPage { get; set; }

        /// <summary>
        /// TotalRecords property
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// TotalActivatedCoupons property including coupons only
        /// </summary>
        //public int TotalActivatedCoupons { get; set; }

        /// <summary>
        /// TotalActivatedCoupons property including cashback only
        /// </summary>
        //public int TotalActivatedCashback { get; set; }

        /// <summary>
        /// TotalActivatedDeals property includng cashback and coupons
        /// </summary>
        //public int TotalActivatedDeals { get; set; }


    }
}
