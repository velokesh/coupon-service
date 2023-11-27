using Coupon.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class GlobalProductCouponsFilter
    {
        public bool IncludeShipToHome { get; set; }

        public OfferSourceType OfferSourceType { get; set; }

        public GlobalProductCouponsFilter()
        {
            IncludeShipToHome = false;
            OfferSourceType = OfferSourceType.Coupon;
            IncludeDeals = false;
        }

        [JsonProperty(PropertyName = "includeDeals")]
        public bool IncludeDeals { get; set; }
    }
}
