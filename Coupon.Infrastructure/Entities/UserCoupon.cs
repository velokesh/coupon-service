#region References
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#endregion

namespace Coupon.Infrastructure.Entities
{
    [Serializable]
    public class UserCoupon
    {
        public UserCoupon(List<UserCouponDetail> user_coupon)
        {
            this.UserCoupons = user_coupon;
        }

        [BsonElement("_id")]
        public ObjectId _id { get; set; }

        [BsonElement("CUST_ID")]
        public int CustId { get; set; }

        [BsonElement("user_coupon")]
        public List<UserCouponDetail> UserCoupons { get; set; }
    }
}
