#region References
using MongoDB.Bson.Serialization.Attributes;
#endregion

namespace Coupon.Infrastructure.Entities
{
    [Serializable]
    public class Category
    {
        [BsonElement("category_level_1")]
        public string? CategoryLevel1 { get; set; }

        [BsonElement("category_level_2")]
        public string? CategoryLevel2 { get; set; }

        [BsonElement("category_level_3")]
        public string? CategoryLevel3 { get; set; }

        [BsonElement("category_level_4")]
        public string? CategoryLevel4 { get; set; }

        [BsonElement("category_level_5")]
        public string? CategoryLevel5 { get; set; }
    }
}
