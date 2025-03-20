using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkilliRandevuAPI.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CustomerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }

        [BsonElement("BusinessId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BusinessId { get; set; }

        [BsonElement("ServiceType")]
        public string ServiceType { get; set; }

        [BsonElement("AppointmentDateTime")]
        public DateTime AppointmentDateTime { get; set; }

        [BsonElement("Duration")]
        public int Duration { get; set; } // Dakika cinsinden

        [BsonElement("Status")]
        public string Status { get; set; } // "Pending", "Confirmed", "Cancelled", "Completed"

        [BsonElement("Notes")]
        public string Notes { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
} 