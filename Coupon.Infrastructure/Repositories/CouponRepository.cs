#region References
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Coupon.Domain.Enums;
using MongoDB.Bson;
#endregion

namespace Coupon.Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly IMongoCollection<Coupons> _couponCollection;
        private readonly IMongoCollection<UserCoupon> _userCouponsCollection;

        public CouponRepository(IOptions<MongoDbSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _couponCollection = database.GetCollection<Coupons>("coupons");
            _userCouponsCollection = database.GetCollection<UserCoupon>("user_coupon");
        }

        public async Task<IEnumerable<Coupons>> GetCoupons(RecommendedCoupon filters)
        {
            var userId = 21100;
            var coupons = Enumerable.Empty<Coupons>();

            // Find the user by ID
            var userFilter = Builders<UserCoupon>.Filter.Eq(u => u.CustId, userId);
            var user = await _userCouponsCollection.Find(userFilter).FirstOrDefaultAsync();

            if (user != null)
            {
                // Extract coupon IDs from user_coupons array
                var userCoupons = user.UserCoupons
                    .Where(uc => uc.IsClipped == 0);
                var couponIds = userCoupons.Select(x => x.OfferId);

                // Find the coupons by IDs
                var couponFilter = Builders<Coupons>.Filter.In(c => c.OfferId, couponIds);
                coupons = await _couponCollection.Find(couponFilter).ToListAsync();

                coupons = coupons
                    .Join(userCoupons,
                    c => c.OfferId,
                    uc => uc.OfferId,
                    (c, uc) =>
                    {
                        c.SortNum = uc.SortNum;
                        return c;
                    })
                    .Where(x => x.ProdtOffrExpiryDt > DateTime.Now)
                    .OrderBy(c => c.SortNum)
                    .Take(filters.NumPageRecords);
            }

            return coupons;
        }

        public async Task<IEnumerable<Coupons>> GetCoupons(CouponSearch filters)
        {
            var userId = 21100;
            var coupons = Enumerable.Empty<Coupons>();

            // Find the user by ID
            var userFilter = Builders<UserCoupon>.Filter.Eq(u => u.CustId, userId);
            var user = await _userCouponsCollection.Find(userFilter).FirstOrDefaultAsync();

            if (user != null)
            {
                // Extract coupon IDs from user_coupons array
                var userCoupons = user.UserCoupons
                    .Where(uc => uc.IsClipped == 0);
                var couponIds = userCoupons.Select(x => x.OfferId);

                // Find the coupons by IDs
                var couponFilter = Builders<Coupons>.Filter.In(c => c.OfferId, couponIds)
                    & GetFilters(filters);
                coupons = await _couponCollection.Find(couponFilter).ToListAsync();

                coupons = coupons
                    .Join(userCoupons,
                    c => c.OfferId,
                    uc => uc.OfferId,
                    (c, uc) =>
                    {
                        c.SortNum = uc.SortNum;
                        return c;
                    })
                    .IfThenElse(() => filters.SortOrderType == SortOrderType.Descending,
                        e => e.OrderByDescending(w => typeof(Coupons).GetProperty(GetColumnName(filters.SortByType))!.GetValue(w, null)),
                        e => e.OrderBy(w => typeof(Coupons).GetProperty(GetColumnName(filters.SortByType))!.GetValue(w, null)))
                    .Take(filters.NumPageRecords);
            }

            return coupons;
        }

        /// <summary>
        /// Returns column name of Coupon equivalent to sort type
        /// </summary>
        /// <param name="sortByType"></param>
        /// <returns></returns>
        private static string GetColumnName(SortByType? sortByType)
        {
            if (sortByType == null)
            {
                return nameof(Coupons.SortNum);
            }
            switch (sortByType)
            {
                case SortByType.OfferValue:
                    return nameof(Coupons.RewardOfferVal);
                case SortByType.ExpiryDate:
                    return nameof(Coupons.OfferExpiryDt);
                case SortByType.BrandName:
                    return nameof(Coupons.BrandName);
                default:
                    return nameof(Coupons.SortNum);
            }
        }

        private static FilterDefinition<Coupons> GetFilters(CouponSearch filters)
        {
            var filter = Builders<Coupons>.Filter.Empty;

            if (filters.Categories != null && filters.Categories.Any())
            {
                filter &= Builders<Coupons>.Filter.In(c => c.RewardCatagoryName, filters.Categories);
            }

            if (filters.Brands != null && filters.Brands.Any())
            {
                filter &= Builders<Coupons>.Filter.In(c => c.BrandName, filters.Brands);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                filter &= Builders<Coupons>.Filter.Regex(c => c.OfferDesc, new BsonRegularExpression($".*{filters.Description}*."));
            }

            return filter;
        }
    }

    public static partial class CouponInfoExtensions
    {
        public static IEnumerable<T> IfThenElse<T>(
        this IEnumerable<T> elements,
        Func<bool> condition,
        Func<IEnumerable<T>, IEnumerable<T>> thenPath,
        Func<IEnumerable<T>, IEnumerable<T>> elsePath)
        {
            return condition()
                ? thenPath(elements)
                : elsePath(elements);
        }
    }
}
