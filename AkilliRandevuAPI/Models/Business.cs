using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkilliRandevuAPI.Models
{
    public class Business
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("BusinessType")]
        public string BusinessType { get; set; }

        [BsonElement("WorkingHours")]
        public Dictionary<string, WorkingHours> WorkingHours { get; set; }

        [BsonElement("Services")]
        public List<Service> Services { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class WorkingHours
    {
        [BsonElement("OpenTime")]
        public TimeSpan OpenTime { get; set; }

        [BsonElement("CloseTime")]
        public TimeSpan CloseTime { get; set; }

        [BsonElement("IsOpen")]
        public bool IsOpen { get; set; }
    }

    public class Service
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Duration")]
        public int Duration { get; set; } // Dakika cinsinden

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
} 