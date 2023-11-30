#region References
using AutoFixture;
using AutoFixture.NUnit3;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.API.Services;
using Grpc.Core;
using Moq;
#endregion

namespace Coupon.Api.Tests
{
    public class CouponSortServiceTests
    {
        #region Get Recommended Coupons Tests
        [Test, CustomAutoData()]
        public async Task GetRecommendedCoupons_ValidInput_ShouldReturnSuccessResponse(
            Fixture fixture,
            [Frozen] IQueryHandler<RecommendedCouponDTO, Task<FilteredCoupon>> getRecommendedCouponsQueryHandler,
            CouponSortService couponSortService)
        {
            var request = fixture
                .Build<API.Protos.RecommendedCouponSearchRequest>()
                .Create();

            var result = fixture.Build<FilteredCoupon>()
                .Create();

            Mock.Get(getRecommendedCouponsQueryHandler)
                .Setup(x => x.ExecuteQuery(It.IsAny<RecommendedCouponDTO>()))
                .ReturnsAsync(result);

            var response = await couponSortService
                .GetRecommendedCoupons(request, new Mock<ServerCallContext>().Object);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Coupons, Has.Count.EqualTo(result.Coupons.Count));
        }

        #endregion
    }
}
