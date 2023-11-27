using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Enums
{

    public enum MixMode
    {
        Mix1, // Coupons,CashBack,Coupons,CashBack
        Mix2,// Coupons,CashBack,CashBack,Coupons,Coupons,CashBack
        CouponsFrist,
        CacheBacksFirst
    }
}
