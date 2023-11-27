using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Enums
{
    public enum SortByType
    {
        //for recommended & targeted coupons/offers
        Recommended = 0,

        OfferType = 1,

        OfferValue = 2,

        BrandName = 3,

        ExpiryDate = 4,

        ActiveDate = 5,

        //for clipped coupons/offers
        //grouped by category and sorted by name
        GroupByCategory = 6,

        SortByName = 7,

        SortByExpiryDate = 8,   //same as 4

        RecentSortAdded = 9,
        ClipDate = 10
    };
}
