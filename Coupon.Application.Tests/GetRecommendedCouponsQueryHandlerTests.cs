#region References
using AutoFixture;
using AutoFixture.NUnit3;
using Coupon.Application.Interfaces;
using Coupon.Application.Queries;
using Coupon.Application.Tests;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Repositories.DTO;
using Coupon.Infrastructure.Repositories.Interfaces;
using Moq;
#endregion

namespace Coupon.Api.Tests
{
    public class GetRecommendedCouponsQueryHandlerTests
    {
        #region Get Recommended Coupons Query Handler Tests
        [Test, CustomAutoData()]
        public async Task GetRecommendedCouponsQueryHandler_ValidInput_ShouldReturnSuccessResponse(
            Fixture fixture,
            [Frozen] ICouponOperation couponOperation,
            GetRecommendedCouponsQueryHandler getRecommendedCouponsQueryHandler)
        {
            var request = fixture
                .Build<RecommendedCouponDTO>()
                .Create();

            var couponsResponse = fixture.Build<CouponDTO>()
                .CreateMany(2);

            Mock.Get(couponOperation)
                .Setup(x => x.GetCoupons())
                .ReturnsAsync(couponsResponse);

            var response = await getRecommendedCouponsQueryHandler
                .ExecuteQuery(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Coupons, Has.Count.EqualTo(couponsResponse.Count()));
        }

        #endregion
    }
}
