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

        public async Task<IEnumerable<DTO.Coupon>> GetCoupons()
        {
            var sqlQuery = @"SELECT offer.*, offer.OFFER_ID as splitPoint, upc.*
                FROM dollargeneral.coupon offer 
                INNER JOIN dollargeneral.coupon_upc_xr_t upc ON offer.OFFER_ID = upc.OFFER_ID
                INNER JOIN dollargeneral.item_mst_t item ON upc.UPC = item.UPC";

            var offerDictionary = new Dictionary<string, DTO.Coupon>();
            return (await _db.
                QueryAsync<Coupon, CouponUpc, Coupon>(sqlQuery,
                (offerInfo, upc) =>
                {
                    if (!offerDictionary.TryGetValue(offerInfo.OfferId, out Coupon? offer))
                    {
                        offer = offerInfo;
                        offerInfo.Upcs = [];
                        offerDictionary.Add(offerInfo.OfferId, offer);
                    }
                    if (upc != null)
                    {
                        offer.Upcs.Add(upc);
                    }

                    return offer;
                }, splitOn: "splitPoint")).Distinct();
        }
    }
}
