#region References
using AutoFixture;
using AutoFixture.NUnit3;
using Coupon.Application.Queries;
using Coupon.Application.Tests;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Repositories.Database.Entities;
using Moq;
#endregion

namespace Coupon.Api.Tests
{
    public class GetRecommendedCouponsQueryHandlerTests
    {
        #region Get Recommended Coupons Query Handler Tests
        [Test, CustomAutoData()]
        public void GetRecommendedCouponsQueryHandler_ValidInput_ShouldReturnSuccessResponse(
            Fixture fixture,
            [Frozen] ICouponRepository couponOperation,
            GetRecommendedCouponsQueryHandler getRecommendedCouponsQueryHandler)
        {
            var request = fixture
                .Build<RecommendedCouponDTO>()
                .Create();

            var couponsResponse = fixture.Build<CouponInfo>()
                .CreateMany(2);

            Mock.Get(couponOperation)
                .Setup(x => x.GetCoupons())
                .Returns(couponsResponse);

            var response = getRecommendedCouponsQueryHandler
                .ExecuteQuery(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Coupons, Has.Count.EqualTo(couponsResponse.Count()));
        }

        #endregion
    }
}
