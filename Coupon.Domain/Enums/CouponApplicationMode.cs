using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Enums
{
    public enum CouponApplicationMode
    {
        /// <summary>
        /// Backwards compatibility for legacy app funcionality
        /// </summary>
        Old = 0,

        /// <summary>
        /// Support for the new app
        /// </summary>
        New = 1
    }
}
