using Coupon.Infrastructure.Repositories.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure
{
    public partial class CouponDbContext : DbContext
    {
        public CouponDbContext()
        {
        }

        public CouponDbContext(DbContextOptions<CouponDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CouponInfo> Coupons { get; set; }

        public virtual DbSet<CouponUpc> CouponUpcXrTs { get; set; }

        public virtual DbSet<Item> ItemMstTs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponInfo>(entity =>
            {
                entity.HasKey(e => e.OfferId).HasName("coupon_pkey");

                entity.ToTable("coupon", "dollargeneral");

                entity.Property(e => e.OfferId)
                    .HasMaxLength(40)
                    .HasColumnName("offer_id");
                entity.Property(e => e.ActivationDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("activation_dt");
                entity.Property(e => e.BrandName)
                    .HasMaxLength(200)
                    .HasColumnName("brand_name");
                entity.Property(e => e.ClearingHouseId)
                    .HasMaxLength(10)
                    .HasColumnName("clearing_house_id");
                entity.Property(e => e.ClearingHouseName)
                    .HasMaxLength(50)
                    .HasColumnName("clearing_house_name");
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .HasColumnName("company_name");
                entity.Property(e => e.CreateDt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_dt");
                entity.Property(e => e.IsAutoActivated).HasColumnName("is_auto_activated");
                entity.Property(e => e.MfrCd)
                    .HasMaxLength(80)
                    .HasColumnName("mfr_cd");
                entity.Property(e => e.MfrId)
                    .HasMaxLength(50)
                    .HasColumnName("mfr_id");
                entity.Property(e => e.MinBasketValue)
                    .HasPrecision(10, 4)
                    .HasColumnName("min_basket_value");
                entity.Property(e => e.MinQty).HasColumnName("min_qty");
                entity.Property(e => e.MinQtyDesc)
                    .HasMaxLength(500)
                    .HasColumnName("min_qty_desc");
                entity.Property(e => e.MinTripCount).HasColumnName("min_trip_count");
                entity.Property(e => e.OfferActDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("offer_act_dt");
                entity.Property(e => e.OfferAssnCd)
                    .HasMaxLength(40)
                    .HasColumnName("offer_assn_cd");
                entity.Property(e => e.OfferCd)
                    .HasMaxLength(50)
                    .HasColumnName("offer_cd");
                entity.Property(e => e.OfferDesc)
                    .HasMaxLength(2000)
                    .HasColumnName("offer_desc");
                entity.Property(e => e.OfferDisclaimer)
                    .HasMaxLength(2000)
                    .HasColumnName("offer_disclaimer");
                entity.Property(e => e.OfferExpiryDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("offer_expiry_dt");
                entity.Property(e => e.OfferFeaturedTxt)
                    .HasMaxLength(2000)
                    .HasColumnName("offer_featured_txt");
                entity.Property(e => e.OfferFinePrt)
                    .HasMaxLength(500)
                    .HasColumnName("offer_fine_prt");
                entity.Property(e => e.OfferGs1)
                    .HasMaxLength(100)
                    .HasColumnName("offer_gs1");
                entity.Property(e => e.OfferImg1)
                    .HasMaxLength(500)
                    .HasColumnName("offer_img_1");
                entity.Property(e => e.OfferImg2)
                    .HasMaxLength(500)
                    .HasColumnName("offer_img_2");
                entity.Property(e => e.OfferShutoffDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("offer_shutoff_dt");
                entity.Property(e => e.OfferSrc)
                    .HasMaxLength(40)
                    .HasColumnName("offer_src");
                entity.Property(e => e.OfferSum)
                    .HasMaxLength(250)
                    .HasColumnName("offer_sum");
                entity.Property(e => e.OfferType)
                    .HasMaxLength(40)
                    .HasColumnName("offer_type");
                entity.Property(e => e.OfferUpc)
                    .HasMaxLength(20)
                    .HasColumnName("offer_upc");
                entity.Property(e => e.ProdtOffrActDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("prodt_offr_act_dt");
                entity.Property(e => e.ProdtOffrExpiryDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("prodt_offr_expiry_dt");
                entity.Property(e => e.RedemptionDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("redemption_dt");
                entity.Property(e => e.RedemptionFreq)
                    .HasMaxLength(20)
                    .HasColumnName("redemption_freq");
                entity.Property(e => e.RedemptionLimitQty).HasColumnName("redemption_limit_qty");
                entity.Property(e => e.RewardCatagoryName)
                    .HasMaxLength(50)
                    .HasColumnName("reward_catagory_name");
                entity.Property(e => e.RewardOfferVal)
                    .HasPrecision(10, 4)
                    .HasColumnName("reward_offer_val");
                entity.Property(e => e.RewardQty).HasColumnName("reward_qty");
                entity.Property(e => e.SourceActDt)
                    .HasMaxLength(100)
                    .HasColumnName("source_act_dt");
                entity.Property(e => e.SourceExpDt)
                    .HasMaxLength(100)
                    .HasColumnName("source_exp_dt");
                entity.Property(e => e.SourceProdtActDt)
                    .HasMaxLength(100)
                    .HasColumnName("source_prodt_act_dt");
                entity.Property(e => e.SourceProdtExpDt)
                    .HasMaxLength(100)
                    .HasColumnName("source_prodt_exp_dt");
                entity.Property(e => e.SourceShutoffDt)
                    .HasMaxLength(100)
                    .HasColumnName("source_shutoff_dt");
                entity.Property(e => e.TgtType)
                    .HasMaxLength(50)
                    .HasColumnName("tgt_type");
                entity.Property(e => e.TimesShopQty).HasColumnName("times_shop_qty");
                entity.Property(e => e.Visible)
                    .HasMaxLength(10)
                    .HasColumnName("visible");
            });

            modelBuilder.Entity<CouponUpc>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("coupon_upc_xr_t", "dollargeneral");

                entity.Property(e => e.OfferId)
                    .HasMaxLength(40)
                    .HasColumnName("offer_id");
                entity.Property(e => e.Upc).HasColumnName("upc");

                entity.HasOne(d => d.Offer).WithMany()
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coupon_upc_xr_t_offer_id_fkey");

                entity.HasOne(d => d.UpcNavigation).WithMany()
                    .HasForeignKey(d => d.Upc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coupon_upc_xr_t_upc_fkey");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Upc).HasName("item_mst_t_pkey");

                entity.ToTable("item_mst_t", "dollargeneral");

                entity.Property(e => e.Upc)
                    .ValueGeneratedNever()
                    .HasColumnName("upc");
                entity.Property(e => e.ExtName)
                    .HasMaxLength(250)
                    .HasColumnName("ext_name");
                entity.Property(e => e.ItemLongDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("item_long_description");
                entity.Property(e => e.MainDesc)
                    .HasMaxLength(50)
                    .HasColumnName("main_desc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}