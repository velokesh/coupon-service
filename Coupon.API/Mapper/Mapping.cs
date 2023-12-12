using AutoMapper;
using Coupon.API.Protos;
using Google.Protobuf.WellKnownTypes;
using Coupon.API;

namespace Coupon_Service.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //sort
            CreateMap<RecommendedCouponSearchRequest, Coupon.Domain.Models.RecommendedCoupon>().ReverseMap().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.FilteredCoupon, RecommendedCouponResponse>().ReverseMap().                
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

            //search
            CreateMap<CouponFilterRequest, Coupon.Domain.Models.CouponSearch>()
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.CouponDescription))
                .ForMember(dest => dest.SortOrderType, opts => opts.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.SortByType, opts => opts.MapFrom(src => src.SortBy))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Coupon.Domain.Models.FilteredCoupon, CouponSearchResponse>().ReverseMap().                
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }

    
}
