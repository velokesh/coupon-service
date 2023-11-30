using AutoMapper;
using Coupon.API.Protos;
using Google.Protobuf.WellKnownTypes;

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

            CreateMap<Coupon.Domain.Models.BaseCoupon, BaseCoupon>()
                .ForMember(dest => dest.ActivationDate, opts => opts.MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.ActivationDate, DateTimeKind.Utc))))
                .ForMember(dest => dest.OfferActivationDate, opts => opts.MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.OfferActivationDate, DateTimeKind.Utc))))
                .ForMember(dest => dest.OfferExpirationDate, opts => opts.MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.OfferExpirationDate, DateTimeKind.Utc))))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }

    
}
