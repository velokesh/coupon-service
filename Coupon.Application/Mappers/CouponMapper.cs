using AutoMapper;
using Coupon.Domain.Enums;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Entities;
using System.Text.RegularExpressions;

namespace Coupon.Application.Mappers
{
    public class CouponMapper : Profile
    {
        public CouponMapper()
        {
            CreateMap<Coupons, BaseCoupon>()
                .ForMember(dest => dest.CouponType, opt => opt.MapFrom(src => CouponSource.None))
                .ForMember(dest => dest.UPCs, opt => opt.Ignore())
                .ForMember(dest => dest.UpcCount, opt => opt.MapFrom(src => src.Upcs.Count))
                .ForMember(dest => dest.IsManufacturerCoupon, opt => opt.MapFrom(src => CheckIsMFGCoupon(src.OfferCd ?? string.Empty)))
                .ForMember(dest => dest.OfferSourceType, opt => opt.MapFrom(src => OfferSourceType.Coupon))
                .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => src.OfferType))
                .ForMember(dest => dest.TargetType, opt => opt.MapFrom(src => src.TgtType))
                .ForMember(dest => dest.OfferCode, opt => opt.MapFrom(src => src.OfferCd))
                .ForMember(dest => dest.OfferID, opt => opt.MapFrom(src => src.OfferId))
                .ForMember(dest => dest.Image1, opt => opt.MapFrom(src => src.OfferImg1))
                .ForMember(dest => dest.Image2, opt => opt.MapFrom(src => src.OfferImg2))
                .ForMember(dest => dest.RecemptionFrequency, opt => opt.MapFrom(src => src.RedemptionFreq))
                .ForMember(dest => dest.OfferActivationDate, opt => opt.MapFrom(src => src.OfferActDt))
                .ForMember(dest => dest.OfferExpirationDate, opt => opt.MapFrom(src => src.OfferExpiryDt))
                .ForMember(dest => dest.OfferDescription, opt => opt.MapFrom(src => src.OfferDesc))
                .ForMember(dest => dest.OfferDisclaimer, opt => opt.MapFrom(src => src.OfferDisclaimer))
                .ForMember(dest => dest.OfferFeaturedText, opt => opt.MapFrom(src => src.OfferFeaturedTxt))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dest => dest.Companyname, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.TimesShopQuantity, opt => opt.MapFrom(src => src.TimesShopQty))
                .ForMember(dest => dest.MinQuantity, opt => opt.MapFrom(src => src.MinQty))
                .ForMember(dest => dest.MinQuantityDescription, opt => opt.MapFrom(src => src.MinQtyDesc))
                .ForMember(dest => dest.OfferSummary, opt => opt.MapFrom(src => src.OfferSum))
                .ForMember(dest => dest.IsAutoActivated, opt => opt.MapFrom(src => src.IsAutoActivated))
                .ForMember(dest => dest.ActivationDate, opt => opt.MapFrom(src => src.ActivationDt))
                .ForMember(dest => dest.AssociationCode, opt => opt.MapFrom(src => src.OfferAssnCd))
                .ForMember(dest => dest.RedemptionLimitQuantity, opt => opt.MapFrom(src => src.RedemptionLimitQty))
                .ForMember(dest => dest.MinBasketValue, opt => opt.MapFrom(src => src.MinBasketValue))
                .ForMember(dest => dest.MinTripCount, opt => opt.MapFrom(src => src.MinTripCount))
                .ForMember(dest => dest.RewaredOfferValue, opt => opt.MapFrom(src => src.RewardOfferVal))
                .ForMember(dest => dest.RewaredCategoryName, opt => opt.MapFrom(src => src.RewardCatagoryName))
                .ForMember(dest => dest.RewardQuantity, opt => opt.MapFrom(src => src.RewardQty))
                .ForMember(dest => dest.Visible, opt => opt.MapFrom(src => src.Visible))
                .ForMember(dest => dest.OfferToken, opt => opt.MapFrom(src => src.OfferId))
                .ForMember(dest => dest.ProductEligible, opt => opt.MapFrom(src => true))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        private static bool CheckIsMFGCoupon(string offerCode)
        {
            return !Regex.IsMatch(offerCode, "X\\d{6}");
        }
    }
}
