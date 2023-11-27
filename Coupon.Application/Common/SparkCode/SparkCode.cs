using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Common.SparkCode
{
    public class SparkCode
    {
       
        public SparkCode(Guid v, string d) { Value = v; Description = d; }
        public Guid Value { get; private set; }
        public string Description { get; private set; }


        //api/sort/v3
        public static readonly SparkCode InvalidinputParameter = new SparkCode(new Guid("dbdc05a2-2523-4101-b266-aaf3c8dee22b"), "Invalid input parameter passed");


        //api/coupon/search
        //input validation failed
        public static readonly SparkCode InputValidationFailed = new SparkCode(new Guid("3bcda9a8-2c83-49af-89f0-c37321624fee"), "Input failed validation");


    }
}
