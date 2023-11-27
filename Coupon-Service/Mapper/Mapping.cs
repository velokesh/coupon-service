using AutoMapper;
using Coupon_Service.Protos;

namespace Coupon_Service.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RecommendedCouponSearchRequest, Coupon.Domain.Models.RecommendedCouponDTO>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.FilteredCoupon, FilteredCoupon>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.CouponPagination, CouponPagination>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.CouponCategory, CouponCategory>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.CouponBrand, CouponBrand>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.BaseCoupon, BaseCoupon>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }

    
}
