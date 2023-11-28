#region References
using AutoFixture;
using AutoFixture.NUnit3;
using Coupon.Domain.Models;
using Coupon_Service.Services;
using Grpc.Core;
using MediatR;
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
            [Frozen] IMediator mediator,
            CouponSortService couponSortService)
        {
            var request = fixture
                .Build<Coupon_Service.Protos.RecommendedCouponSearchRequest>()
                .Create();

            var result = fixture.Build<FilteredCoupon>()
                .Create();

            Mock.Get(mediator)
                .Setup(x => x.Send(It.IsAny<IRequest<FilteredCoupon>>(), default))
                .ReturnsAsync(result);

            var response = await couponSortService
                .GetRecommendedCoupons(request, new Mock<ServerCallContext>().Object);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Coupons, Has.Count.EqualTo(result.Coupons.Count));
        }

        #endregion
    }
}
