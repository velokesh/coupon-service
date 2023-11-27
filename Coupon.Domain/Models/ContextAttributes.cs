using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class ContextAttributes
    {
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }
}
