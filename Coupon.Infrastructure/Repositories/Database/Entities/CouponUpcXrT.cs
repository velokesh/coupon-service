using System;
using System.Collections.Generic;

namespace Coupon.Infrastructure.Repositories.Database.Entities
{

    public class CouponUpcXrT
    {
        public string OfferId { get; set; } = null!;

        public long Upc { get; set; }

        public virtual CouponInfo Offer { get; set; } = null!;

        public virtual ItemMstT UpcNavigation { get; set; } = null!;
    }
}