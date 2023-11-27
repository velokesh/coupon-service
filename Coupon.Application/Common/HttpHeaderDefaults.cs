using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Common
{
    public sealed class HttpHeaderDefaults
    {
        private readonly string displayName;
        private readonly int value;

        HttpHeaderDefaults(int value, string displayName) 
        {
            this.displayName = displayName;
            this.value = value;
        }

        /// <summary>
        /// The unknown header
        /// </summary>
        public static readonly HttpHeaderDefaults Unknown = new HttpHeaderDefaults(-1, "Unknown");

        /// <summary>
        /// The X-DG-AppToken header key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_APP_TOKEN_KEY = new HttpHeaderDefaults(1, "X-DG-AppToken");

        /// <summary>
        /// The X-DG-PartnerAPIToken header key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_PARTNER_API_TOKEN_KEY = new HttpHeaderDefaults(2, "X-DG-PartnerAPIToken");

        /// <summary>
        /// The X-DG-AppSessionTokne header key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_APP_SESSION_TOKEN_KEY = new HttpHeaderDefaults(3, "X-DG-AppSessionToken");

        /// <summary>
        /// The X-DG-DeviceUniqueID heaer key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_DEVICE_UNIQUE_ID_KEY = new HttpHeaderDefaults(4, "X-DG-DeviceUniqueID");

        /// <summary>
        /// X-DG-CustomerGUID header key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_CUSTOMER_GUID_KEY = new HttpHeaderDefaults(5, "X-DG-CustomerGUID");

        /// <summary>
        /// The X-Spark header key
        /// </summary>
        public static readonly HttpHeaderDefaults DG_SPARK_CODE_KEY = new HttpHeaderDefaults(27, "X-Spark");
    }
}
