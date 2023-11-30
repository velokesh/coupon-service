using Coupon.Infrastructure.Repositories.DTO;
using Coupon.Infrastructure.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Coupon.Infrastructure.Repositories.Implementation
{
    public class CouponOperation : ICouponOperation
    {
        private readonly IDbConnection _db;

        public CouponOperation(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("CouponDb"));
        }

        public async Task<IEnumerable<CouponDTO>> GetCoupons()
        {
            var sqlQuery = @"SELECT offer.*, offer.OFFER_ID as splitPoint, upc.*
                FROM dollargeneral.coupon offer 
                INNER JOIN dollargeneral.coupon_upc_xr_t upc ON offer.OFFER_ID = upc.OFFER_ID
                INNER JOIN dollargeneral.item_mst_t item ON upc.UPC = item.UPC";

            var couponDictionary = new Dictionary<string, CouponDTO>();
            return (await _db.
                QueryAsync<CouponDTO, CouponUpc, CouponDTO>(sqlQuery,
                (couponInfo, upc) =>
                {
                    if (!couponDictionary.TryGetValue(couponInfo.OfferId, out CouponDTO? coupon))
                    {
                        coupon = couponInfo;
                        couponInfo.Upcs = [];
                        couponDictionary.Add(couponInfo.OfferId, coupon);
                    }
                    if (upc != null)
                    {
                        coupon.Upcs.Add(upc);
                    }

                    return coupon;
                }, splitOn: "splitPoint")).Distinct();
        }
    }
}
