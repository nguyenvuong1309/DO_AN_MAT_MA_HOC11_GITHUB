using MongoDB.Bson.Serialization.Attributes;
namespace BEN_TRUNG_GIAN
{
    public class Contract
    {
        [BsonElement("CONTRACT")]
        public string CONTRACT { get; set; }
        public Contract(string c)
        {
            this.CONTRACT = c;
        }
    }
}
