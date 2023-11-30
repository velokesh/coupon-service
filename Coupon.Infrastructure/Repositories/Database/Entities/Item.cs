namespace Coupon.Infrastructure.Repositories.Database.Entities
{
    public class Item
    {
        public long Upc { get; set; }

        public string MainDesc { get; set; } = null!;

        public string? ExtName { get; set; }

        public string? ItemLongDescription { get; set; }
    }
}