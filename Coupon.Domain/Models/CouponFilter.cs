using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class CouponFilter
    {
        public CouponFilter()
        {
            FilterValues = new List<string>();
        }

        /// <summary>
        /// FilterTypes
        /// </summary>
        [JsonProperty("filterType")]
        public string FilterType { get; set; }

        /// <summary>
        /// FilterValues
        /// </summary>
        [JsonProperty("filterValues")]
        public List<string> FilterValues { get; set; } = new List<string>();
    }
}
