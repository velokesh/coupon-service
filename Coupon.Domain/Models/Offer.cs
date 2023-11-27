using Coupon.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class Offer : ICloneable
    {
        public const int MaxNumberOfItemsToApply = 9999;
        public const int MinNumberOfItemsToApply = 1;

        public bool QualifiedOnBuySide { get; set; }
        public OfferBuy TheBuySide { get; set; }

        public OfferGet TheGetSide { get; set; }

        //DESCRIPTION VARCHAR2(100)
        public string Description { get; set; }

        //SCHED_ID	NUMBER(5)
        public int ScheduleID { get; set; }

        //OFFR_ID	NUMBER(18)
        public Int64 OfferID { get; set; }

        //OFFR_TYP_ID NUMBER(3)
        public int OfferTypeID { get; set; }

        //PROCESS_ORDR	NUMBER(5)
        public int ProcessOrder { get; set; }

        //STAKG_ID	NUMBER(3)
        public int StackingID { get; set; }

        //MODIFIER_ID	NUMBER(3)
        public int ModifierID { get; set; }

        //IS_CPN_REQD	NUMBER(1)
        public int IsCouponRequired { get; set; }

        //MAX_DSCNTS_PER_CPN	NUMBER(5)
        public int MaxDiscountsPerCoupon { get; set; }

        //MAX_CPNS_PER_BSKT	NUMBER(5)
        public int MaxCouponsPerBasket { get; set; }

        //IS_PURCH_REQD	NUMBER(1)
        public int IsPurchaseRequired { get; set; }

        public DateTime ExpirationDate { get; set; }
        [JsonIgnore]
        public long? BetterOfferId { get; set; }

        [JsonIgnore]
        public RecordType RecordType { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        /*
                offer modifiers...
        0	1	Regular offer
        1	1	Allow free Prepaid Card
        2	1	Spread evenly across all items
        3	1	Cascade amount off of offer


                offer stacking...
        0	1	Exclusive
        1	1	Allow with Identical product only
        9	1	Allow with other discounted items


        offer types...
        Bounceback
        Merch Department
        UPC/SKU
        Merchandiser
        Merchandiser Family
        Basket 


        coupon stacking...
        0	1	None
        1	1	Discount only
        2	1	Coupon only
        3	1	Discount and coupon
        4	1	Basket only
        5	1	Discount and Basket
        6	1	Coupon and Basket
        7	1	Discount, Coupon, and Basket 



            */

        [JsonIgnore]
        public int AppliedCount { get; set; }

    }
}
