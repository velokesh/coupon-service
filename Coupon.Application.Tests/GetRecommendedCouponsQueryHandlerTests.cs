#region References
using AutoFixture;
using AutoFixture.NUnit3;
using Coupon.Application.Queries;
using Coupon.Application.Tests;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Entities;
using Moq;
#endregion

namespace Coupon.Application.Tests
{
    public class GetRecommendedCouponsQueryHandlerTests
    {
        #region Get Recommended Coupons Query Handler Tests
        [Test, CustomAutoData()]
        public async Task GetRecommendedCouponsQueryHandler_ValidInput_ShouldReturnSuccessResponse(
            Fixture fixture,
            [Frozen] ICouponRepository couponOperation,
            GetRecommendedCouponsQueryHandler getRecommendedCouponsQueryHandler)
        {
            var request = fixture
                .Build<RecommendedCoupon>()
                .Create();

            var couponsResponse = fixture.Build<Coupons>()
                .Without(x => x.Id)
                .CreateMany(2);

            Mock.Get(couponOperation)
                .Setup(x => x.GetCoupons(It.IsAny<RecommendedCoupon>()))
                .ReturnsAsync(couponsResponse);

            var response = await getRecommendedCouponsQueryHandler
                .ExecuteQuery(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Coupons, Has.Count.EqualTo(couponsResponse.Count()));
        }

        #endregion
    }
}
