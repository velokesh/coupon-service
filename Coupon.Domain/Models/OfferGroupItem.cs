using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class OfferGroupItem
    {
        public Int64 UPC { get; set; }

        public decimal MiniumumRetailPrice { get; set; }


        //IS_EXCLD	NUMBER(1)
        public int IsExcluded { get; set; }
        public string GroupItemAndOr { get; set; }
    }
}
