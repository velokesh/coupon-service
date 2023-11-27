using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Domain.Models
{
    public class OfferGroup
    {

        //GRP_TYP_ID	NUMBER(1)
        public int GroupTypeID { get; set; }

        //GRP_ID NUMBER(5)
        public int GroupID { get; set; }

        //METHD_VAL	NUMBER(10,4)
        public decimal MethodValue { get; set; }

        //GET_METHOD	VARCHAR2(50)
        public string Method { get; set; }

        //GRP_AND_OR	VARCHAR2(3)
        public string GroupAndOr { get; set; }

        public List<OfferGroupItem> GroupItems { get; set; }

        //Target only.Buy side will have -999
        public int MaxGroupDiscountQty { get; set; }

        //Target only. Buy side will have -999.99 or -10000
        public decimal MaxGroupDiscountAmt { get; set; }

        //IS_MIN_OF_ONE	NUMBER(1)
        public int IsMinOfOne { get; set; }

        //Buy only.Target side will have -1
        public int IsMinByGroup { get; set; }

        //flags (bitwise METHOD_QUALIFIER)
        public long GroupFlags { get; set; }

        //NO_PURCH  1 means requirement is met if item(s) in group are not purchased, 0 default. This is a Buy side only flag. -1000 for target. 
        public int IsMetNoPurchase { get; set; }

        //Do not mark item(s) in group to be discounted but include in totals. 
        public int IsNoShow { get; set; }

        //Possible values are 0, 1, 2, or 9. This is a buy side flag. -1 for target. 
        public int FlaggedItemCode { get; set; }

    }
}
